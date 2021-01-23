using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public Vector2 jumpForce_Grounded;

    private bool jumpRequest_Grounded;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        jumpRequest_Grounded = false;


        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && GroundCheck.isGrounded)
        {
            jumpRequest_Grounded = true;
        }
    }

    private void FixedUpdate()
    {
        if(jumpRequest_Grounded)
        {
            jumpRequest_Grounded = false;
            rb.AddForce(jumpForce_Grounded, ForceMode2D.Impulse);
        }
    }
}
