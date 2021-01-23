using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_ForestCritterAttack : StateMachineBehaviour
{
    public int damageOutput;

    private Attacking att;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        att = animator.GetComponent<Attacking>();
        att.enabled = false;
        animator.SetBool("Attack", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float absDistX = PlayerSpotting.playerRef ? Mathf.Abs(animator.gameObject.transform.position.x - PlayerSpotting.playerRef.transform.position.x) : 100f;
        float absDistY = PlayerSpotting.playerRef ? Mathf.Abs(animator.gameObject.transform.position.y - PlayerSpotting.playerRef.transform.position.y): 100f;

        if (absDistX <= Following.minDistBeforeAttacking && absDistY<= Following.minDistBeforeAttacking && !animator.GetBool("IsStunned"))
        {
            PlayerSpotting.playerRef.GetComponent<Health>().TakeDamage(damageOutput);
        }

        att = animator.GetComponent<Attacking>();
        att.enabled = true;

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
