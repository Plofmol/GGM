using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTom : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float jumpForce = 7f; // Adjust the jump force as needed
    private Rigidbody2D rb;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer; // Optionally, you can still use a LayerMask if needed.



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player movement
        float moveDirection = Input.GetAxis("Horizontal");  
        if(moveDirection != 0)
        {
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        Debug.Log(isGrounded);
        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Jump logic
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // You can add additional logic here, such as handling interactions, shooting, etc.
}
