using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpotting : MonoBehaviour
{
    
    public static bool isPlayerSpotted;
    public static GameObject playerRef;

    public string spottedPlayerAnimBoolName = "PlayerSpotted";
    public float spotDistance;
    public Transform spotCenter;
    public LayerMask whatIsPlayer;

    //private int spottedAnimTriggerInt;
    
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerSpotted = false;
        playerRef = null;

        //spottedAnimTriggerInt = 0;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerSpotted)
        {
            anim.SetBool(spottedPlayerAnimBoolName, true);
        }
        else if(!isPlayerSpotted)
        {
            anim.SetBool(spottedPlayerAnimBoolName, false);
        }

    }

    private void FixedUpdate()
    {
        Collider2D player = Physics2D.OverlapCircle( spotCenter.position, spotDistance, whatIsPlayer);
        if (player != null)
        {
            isPlayerSpotted = true;
            playerRef = player.gameObject;
        }
        else
        {
            isPlayerSpotted = false;
            playerRef = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(spotCenter.position, spotDistance);
    }
}
