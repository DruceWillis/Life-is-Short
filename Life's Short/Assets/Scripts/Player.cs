using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float dashRange = 5f;
    [SerializeField] float jumpForce = 6f;
    
    public bool isGrounded;

    Animator playerAnimator;
    Rigidbody2D myRigidbody;
    bool facingRight = true;

    private GameObject boxRef;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        boxRef = GameObject.Find("BoxRef");
        isGrounded = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Move();
        Dash();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Attack();
        Jump();
    }

    private void Move()
    {
        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        
        if (horizontal > 0)
        {
            playerAnimator.SetFloat("Speed", 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
            
        }
        else if (horizontal < 0)
        {
            playerAnimator.SetFloat("Speed", 1);
            transform.localRotation = Quaternion.Euler(0, 180f, 0);
            facingRight = false;
            
        }
        else 
        {
            playerAnimator.SetFloat("Speed", 0);
        }

        //Debug.Log(horizontal);
        var positionY = transform.position.y;
        horizontal += transform.position.x;
        transform.position = new Vector2(horizontal, positionY); 

    }

    private void Attack()
    {
    }

    private void Dash()
    {
    }

    private void Jump()
    {
        RaycastHit2D hitInfo;
        Vector2 boxSize = new Vector2(1f, 0.01f);

        if (facingRight)
        {
            hitInfo = Physics2D.BoxCast(transform.position + new Vector3(0f, 0.17f, 0), boxSize, 0f, Vector2.down, 0.01f);
            // boxRef.transform.position = transform.position + new Vector3(-0.5f, 0.17f, 0);
            // boxRef.transform.localScale = boxSize;

            if (hitInfo)
            {
                Debug.Log("Touching the ground!" + hitInfo.transform.gameObject.name);
                isGrounded = true;
            }
            else
            {
                Debug.Log("Not touching the ground!");
                isGrounded = false;
            }
        }
        else
        {
            hitInfo = Physics2D.BoxCast(transform.position + new Vector3(0.9f, 0.17f, 0), boxSize, 0f, Vector2.down, 0.01f);
            // boxRef.transform.position = transform.position + new Vector3(0.5f, 0.17f, 0);
            // boxRef.transform.localScale = boxSize;

            if (hitInfo)
            {
                Debug.Log("Touching the ground!" + hitInfo.transform.gameObject.name);
                isGrounded = true;
            }
            else
            {
                Debug.Log("Not touching the ground!");
                isGrounded = false;
            }
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
            myRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        playerAnimator.SetBool("Jump", !isGrounded);
    }
}
