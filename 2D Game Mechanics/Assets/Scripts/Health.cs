using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    public static int currHealth;
    [SerializeField]
    public static int maxHealth = 100;


    public float collisionDamageCooldown;
    public Vector2 getDamageForce;

    
    private float currCollisionDamageCooldown;

    private Rigidbody2D rb;
    private PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        currCollisionDamageCooldown = 0;

        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();

    }

    private void Update()
    {
        if(currCollisionDamageCooldown < collisionDamageCooldown)
        {
            currCollisionDamageCooldown += Time.deltaTime;
        }
        else if(currCollisionDamageCooldown > collisionDamageCooldown)
        {
            currCollisionDamageCooldown = collisionDamageCooldown;
        }
    }

    // Update is called once per frame

    public void TakeDamage(int damage)
    {
        if(currHealth > damage)
        {
            pm.enabled = false;
            currHealth -= damage;
            CamDictionary.CamShake(0.2f, 10f);
            rb.AddForce(getDamageForce, ForceMode2D.Impulse);
            pm.enabled = true;

        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9 && currCollisionDamageCooldown == collisionDamageCooldown)
        {
            print(collision.gameObject);
            TakeDamage(10);
            currCollisionDamageCooldown = 0;
        }
    }
}
