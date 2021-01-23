using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walling : MonoBehaviour
{
    public float wallingGravityModifier;

    private PlayerMovement pm;
    private PlayerJump pj;
    private BetterJump bj;
    private SwordAttacking sa;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {

        pm = GetComponent<PlayerMovement>();
        pj = GetComponent<PlayerJump>();
        bj = GetComponent<BetterJump>();
        rb = GetComponent<Rigidbody2D>();
        sa = GetComponent<SwordAttacking>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(WallingCheck.isWalling && !GroundCheck.isGrounded)
        {
            if(transform.localScale.x > 0 && Input.GetAxis("Horizontal") > pm.moveThreshold)
            {
                ToggleComponents(false);
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.gravityScale = wallingGravityModifier;
            }
            else if(transform.localScale.x < 0 && Input.GetAxis("Horizontal") < -pm.moveThreshold)
            {
                ToggleComponents(false);
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.gravityScale = wallingGravityModifier;   
            }
            else
            {
                ToggleComponents(true);
                //rb.gravityScale = 1f;
            }
           
        }
        else
        {
            ToggleComponents(true);
            //rb.gravityScale = 1f;
        }
    }

    void ToggleComponents (bool val)
    {
        pm.enabled = val;
        pj.enabled = val;
        bj.enabled = val;
        sa.enabled = val;
    }
}
