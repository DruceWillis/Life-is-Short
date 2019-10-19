using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Attack();
    }

    private void Move()
    {
        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        
        if (horizontal > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (horizontal < 0)
            transform.localScale = new Vector3(1, 1, 1);

        var positionY = transform.position.y;
        horizontal += transform.position.x;
        transform.position = new Vector2(horizontal, positionY);

    }

    private void Attack()
    {
        playerAnimator.SetTrigger("Attack");
    }
}
