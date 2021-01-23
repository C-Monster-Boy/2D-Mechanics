using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public float attackCooldownTimer;
    public string attackPlayerAnimBoolName = "Attack" ;

    private float currAttackCooldownTimer;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currAttackCooldownTimer = 0;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Following.isInAttackingRange && currAttackCooldownTimer == 0 && !anim.GetBool(attackPlayerAnimBoolName))
        {
            anim.SetBool(attackPlayerAnimBoolName, true);
            currAttackCooldownTimer = attackCooldownTimer;
        }
        else if(!Following.isInAttackingRange)
        {
            currAttackCooldownTimer = 0;
        }

        if(currAttackCooldownTimer > 0)
        {
            currAttackCooldownTimer -= Time.deltaTime;
        }
        else if(currAttackCooldownTimer < 0)
        {
            currAttackCooldownTimer = 0;
        }
    }
}
