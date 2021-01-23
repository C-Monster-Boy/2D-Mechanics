using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float moveInput;

    //public vars
    public float moveSpeedNormal;
    [Range(0,1)]
    public float moveThreshold;

    //private vars
   

    //private components
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        if(moveInput > moveThreshold )
        {
            rb.velocity = new Vector2(moveSpeedNormal, rb.velocity.y);
            if (transform.localScale.x < 0)
            {
                Flip();
            }
        }
        else if (moveInput < -moveThreshold)
        {
            rb.velocity = new Vector2(-moveSpeedNormal, rb.velocity.y);
            if(transform.localScale.x > 0)
            {
                Flip();
            }
        }
        else 
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void Flip()
    {
        Vector2 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }
}
