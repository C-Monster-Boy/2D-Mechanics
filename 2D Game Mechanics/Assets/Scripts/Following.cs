using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{
    public static bool isInAttackingRange;
    public static float distFromPlayer;
    public static float minDistBeforeAttacking;

    public string attackPlayerAnimBoolName = "Attack";


    public float followSpeed;
    public float minDistance;
    
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        isInAttackingRange = false;
        minDistBeforeAttacking = minDistance;
        distFromPlayer = -1;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        if(PlayerSpotting.isPlayerSpotted && !anim.GetBool(attackPlayerAnimBoolName))
        {
            distFromPlayer = transform.position.x - PlayerSpotting.playerRef.transform.position.x;
            if(Mathf.Abs(distFromPlayer) > minDistance)
            {
                isInAttackingRange = false;

                if(distFromPlayer > 0)
                {
                    if(transform.localScale.x < 0)
                    {
                        Flip();
                    }
                    rb.velocity = (new Vector2(-followSpeed, 0f));
                }
                else if(distFromPlayer < 0)
                {
                    if (transform.localScale.x > 0)
                    {
                        Flip();
                    }
                    rb.velocity = (new Vector2(followSpeed, 0f));
                }
            }
            else if(Mathf.Abs(distFromPlayer) <= minDistance)
            {
                rb.velocity = Vector2.zero;
                isInAttackingRange = true;
            }

        }
        else
        {
            rb.velocity = Vector2.zero;
            distFromPlayer = -1;
        }
    }

    void Flip()
    {
        Vector2 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }
}
