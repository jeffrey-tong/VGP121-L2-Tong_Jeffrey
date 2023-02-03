using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    public float speed;
    public float jumpForce;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask isGroundLayer;
    public float groundCheckRadius;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if(speed <= 0)
        {
            speed = 10.0f;
        } 
        if(jumpForce <= 0)
        {
            jumpForce = 650.0f;
        }
        if(groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
        }
        if (!groundCheck)
        {
            groundCheck = GameObject.FindGameObjectWithTag("GroundCheck").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        Vector2 moveDirection = new Vector2(hInput * speed, rb.velocity.y);
        rb.velocity = moveDirection;

        if (isGrounded && Input.GetButtonDown("Jump")) 
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        if(hInput != 0)
        {
            sr.flipX = hInput < 0;
        }
    }
}
