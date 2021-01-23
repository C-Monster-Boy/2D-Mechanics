using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttacking : MonoBehaviour
{
    //public vars
    public string swordAttackAnimTrigger = "SwordAttackForm";
    public float swordMoveChangeDelay;
    public float swordMoveResetDelay;
    public Vector2 attackForce;
    public float damageRadius;
    public Transform damageCenter;
    public LayerMask whatIsDamageableByPlayer;
    public LayerMask whatIsHitableByPlayer;
    public LayerMask whatIsEnemy;


    //private vars
    private bool damageItems;
    private bool canAcceptInput;
    private float currSwordMoveChangeDelay;
    private float currSwordMoveResetDelay;

    //components
    private PlayerMovement pm;
    private Walling w;
    private Rigidbody2D rb;
    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        //init var
        damageItems = false;
        canAcceptInput = true;
        currSwordMoveResetDelay = 0;
        currSwordMoveChangeDelay = 0;


        //init components
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();
        w = GetComponent<Walling>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canAcceptInput && Input.GetButtonDown("MeleeAttack"))
        {
            canAcceptInput = false;
            currSwordMoveChangeDelay = 0;
            currSwordMoveResetDelay = 0;
            ToggleComponents(false);
            int currSwordMove = anim.GetInteger(swordAttackAnimTrigger);
            if(currSwordMove < 4)
            {
                anim.SetInteger(swordAttackAnimTrigger, currSwordMove + 1);
            }
            else
            {
                anim.SetInteger(swordAttackAnimTrigger, 2);
            }
            damageItems = true;
        }

        if(!canAcceptInput)
        {
            if(currSwordMoveChangeDelay < swordMoveChangeDelay)
            {
                currSwordMoveChangeDelay += Time.deltaTime;
            }
            else
            {
                canAcceptInput = true;
            }
        }

        if(canAcceptInput && currSwordMoveChangeDelay >= swordMoveChangeDelay)
        {
            if (currSwordMoveResetDelay < swordMoveResetDelay)
            {
                currSwordMoveResetDelay += Time.deltaTime;
            }
            else if(currSwordMoveResetDelay > swordMoveResetDelay)
            {
                anim.SetInteger(swordAttackAnimTrigger, 0);
                ToggleComponents(true);
                currSwordMoveChangeDelay = swordMoveChangeDelay;
            }
        }
    }

    private void FixedUpdate()
    {
        if(damageItems)
        {
            if (GroundCheck.isGrounded)
            {

                rb.velocity = new Vector2(0, rb.velocity.y);  
            }

            Collider2D[] damageableColliders = Physics2D.OverlapCircleAll(damageCenter.position, damageRadius, whatIsDamageableByPlayer);
            Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(damageCenter.position, damageRadius, whatIsEnemy);
            Collider2D[] hitableColliders = Physics2D.OverlapCircleAll(damageCenter.position, damageRadius, whatIsHitableByPlayer);
            foreach (Collider2D c in enemyColliders)
            {
                c.gameObject.GetComponent<EnemyHealth>().TakeDamage(40);
            } 
            if(damageableColliders.Length > 0)
            {
                /*if (transform.localScale.x < 0)
                {
                    rb.AddForce(attackForce, ForceMode2D.Impulse);
                }
                else if (transform.localScale.x > 0)
                {
                    Vector2 negAttackForce = new Vector2(-attackForce.x, attackForce.y);
                    rb.AddForce(negAttackForce, ForceMode2D.Impulse);
                }*/
                //#TODO Add damage
                //CamDictionary.CamShake(0.02f, 2f);
            }
            else
            {
                Collider2D[] allCollidersInRange = Physics2D.OverlapCircleAll(damageCenter.position, damageRadius, whatIsHitableByPlayer);
                if(allCollidersInRange.Length > 0)
                {
                    CamDictionary.CamShake(0.07f, 3f);
                }
            }
           
            damageItems = false;
        }
    }

    void ToggleComponents(bool val)
    {
        pm.enabled = val;
        w.enabled = val;

        /*if (GroundCheck.isGrounded)
        {
           
            //rb.velocity = new Vector2(0, rb.velocity.y);  
        }*/
        if(!GroundCheck.isGrounded)
        {
            if (!val)
            {
                pm.enabled = true;
            }
        } 
      
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        Gizmos.DrawWireSphere(damageCenter.position, damageRadius);
    }
}
