using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallingJump : MonoBehaviour
{
    public Vector2 wallJumpForce;

    private bool wallJumpRequest;

    private Rigidbody2D rb;
    private PlayerMovement pm;
    private PlayerJump pj;
    private BetterJump bj;
    private Walling walling;

    // Start is called before the first frame update
    void Start()
    {
        wallJumpRequest = false;

        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();
        pj = GetComponent<PlayerJump>();
        bj = GetComponent<BetterJump>();
        walling = GetComponent<Walling>();
    }

    // Update is called once per frame
    void Update()
    {
        if(WallingCheck.isWalling && Input.GetButtonDown("Jump"))
        {
            wallJumpRequest = true;
            ToggleComponents(false);
        }
    }

    private void FixedUpdate()
    {
        if(wallJumpRequest)
        {
            rb.gravityScale = 1f;

            if (transform.localScale.x > 0)
            {
                Vector2 tempForce = wallJumpForce;
                tempForce.x *= -1;
                rb.AddForce(tempForce, ForceMode2D.Impulse);
                Flip();
            }
            else
            {
                rb.AddForce(wallJumpForce, ForceMode2D.Impulse);
                Flip();
            }

            ToggleComponents(true);
        
            wallJumpRequest = false;
        }
    }

    void ToggleComponents(bool val)
    {
        pm.enabled = val;
        pj.enabled = val;
        bj.enabled = val;
        walling.enabled = val;
    }

    void Flip()
    {
        Vector2 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }
}
