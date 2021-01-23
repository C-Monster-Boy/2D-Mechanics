using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public Vector2 damageForce;
    public float stunTime;

    public ParticleSystem damageEffect;

    public string enemyStunnedAnimBoolName = "IsStunned";
    public string enemyDeathAnimTriggerName = "IsDead";

    [SerializeField]
    private int currHealth;

    private Rigidbody2D rb;
    private Animator anim;
    private PlayerSpotting ps;
    private Following foll;
    private Attacking att;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        ps = GetComponent<PlayerSpotting>();
        foll = GetComponent<Following>();
        att = GetComponent<Attacking>() ;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        if(currHealth > damage)
        {
            StartCoroutine(GetDamage(damage));
        }
        else
        {
            damageEffect.Play();
            GetComponent<ForestCritterDeathHands>().enabled = true;
            ToggleCompnents(false);
            ps.enabled = false;
            anim.SetTrigger(enemyDeathAnimTriggerName);
            gameObject.layer = 14;
            rb.velocity = Vector2.zero;
           
            this.enabled = false;
        }
    }

    void ToggleCompnents(bool val)
    {
       foll.enabled = val;
       att.enabled = val;
    }

    IEnumerator GetDamage(int val)
    {
        ToggleCompnents(false);
        rb.velocity = Vector2.zero;
        currHealth -= val;

        anim.SetBool(enemyStunnedAnimBoolName, true);

        damageEffect.Play();

        if (transform.localScale.x > 0)
        {
            rb.AddForce(damageForce, ForceMode2D.Impulse);
        }
        else
        {
            Vector2 negForce = damageForce;
            negForce.x *= -1;
            rb.AddForce(negForce, ForceMode2D.Impulse);
        }

        


        print("Critter Damaged");

        yield return new WaitForSeconds(stunTime);

        ToggleCompnents(true);
        anim.SetBool(enemyStunnedAnimBoolName, false);
    }

}
