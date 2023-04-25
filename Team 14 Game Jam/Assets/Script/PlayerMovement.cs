using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    private float jumpForce = 7;
    private float movementSpeed = 10;
    public AudioSource impactSound;


    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
        float verticalInput = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = transform.up * jumpForce;
        }
        transform.position += transform.right  * movementSpeed * Time.deltaTime * horizontalInput ;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 3 && IsGrounded())
        {
            impactSound.Play();
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);
    }


}
