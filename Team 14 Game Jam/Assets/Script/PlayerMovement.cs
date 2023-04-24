using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    private float jumpForce = 5;
    private float movementSpeed = 10;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
        float verticalInput = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1

        if (Input.GetKey(KeyCode.Space)/* && IsGrounded()*/)
        {
            rb.velocity = transform.up * jumpForce;
        }
        transform.position += transform.right  * movementSpeed * Time.deltaTime * horizontalInput ;

    }
    /*
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 1f, ground);
    }
    */
}
