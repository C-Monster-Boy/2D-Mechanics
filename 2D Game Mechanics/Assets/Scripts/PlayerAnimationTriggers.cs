using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    public string runAnimBool = "IsRunning";
    public string groundedAnimBool = "IsGrounded";
    public string wallingAnimBool = "IsWalling";

    private Animator anim;
    private PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.moveInput > pm.moveThreshold || PlayerMovement.moveInput < -pm.moveThreshold)
        {
            anim.SetBool(runAnimBool, true);
        }
        else
        {
            anim.SetBool(runAnimBool, false);
        }

        if(GroundCheck.isGrounded && WallingCheck.isWalling)
        {
            anim.SetBool(wallingAnimBool, false);
            anim.SetBool(groundedAnimBool, true);
        }

        if(!GroundCheck.isGrounded && WallingCheck.isWalling)
        {
            anim.SetBool(wallingAnimBool, true);
        }
        else
        {
            anim.SetBool(wallingAnimBool, false);
        }


        if(!GroundCheck.isGrounded && !WallingCheck.isWalling)
        {
            anim.SetBool(groundedAnimBool, false);
        }
        else if(GroundCheck.isGrounded && !WallingCheck.isWalling)
        {
            anim.SetBool(groundedAnimBool, true);
        }
    }
}
