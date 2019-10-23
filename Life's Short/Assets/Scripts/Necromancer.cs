using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float dashRange = 5f;

    Animator playerAnimator;
    Rigidbody2D myRigidbody;
    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Dash();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Attack();
    }

    private void Move()
    {
        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(2, 2 ,1);
            playerAnimator.SetFloat("Speed", 1);
            facingRight = true;
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-2, 2 ,1);
            playerAnimator.SetFloat("Speed", 1);
            facingRight = false;
        }
        else 
        {
            playerAnimator.SetFloat("Speed", 0);
        }

        Debug.Log(horizontal);
        var positionY = transform.position.y;
        horizontal += transform.position.x;
        transform.position = new Vector2(horizontal, positionY);


    }

    private void Attack()
    {
        playerAnimator.SetTrigger("Attack");
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && facingRight)
        {
            myRigidbody.MovePosition(new Vector2(transform.position.x + dashRange, transform.position.y));
            playerAnimator.SetTrigger("Dash");
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && !facingRight)
        {
            myRigidbody.MovePosition(new Vector2(transform.position.x - dashRange, transform.position.y)); 
            playerAnimator.SetTrigger("Dash");
        }
    }
}
