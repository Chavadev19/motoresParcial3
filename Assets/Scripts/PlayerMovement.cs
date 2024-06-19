using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;

    [Header("Jump Values")]
    [SerializeField] private float jumpForce;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("ControlHorizontal");

        if (horizontalInput != 0)
        {
            
            transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if(Input.GetButtonDown("JumpControl") && isGrounded)
        {
            Debug.Log("Pulsando A");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }


}
