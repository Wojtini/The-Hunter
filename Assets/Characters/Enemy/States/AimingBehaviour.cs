using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingBehaviour : StateMachineBehaviour
{
    public Transform playerTransform;
    public float dispersionModifier = 1f;
    public float aimingTime = 2f;
    public float rotationSpeed = 2f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        aimingTime = 2f;
        animator.ResetTrigger("shoot");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform currRot = animator.gameObject.transform;
        float trueRot = rotationSpeed * Time.deltaTime;
        Vector3 rotDelta = Vector3.RotateTowards(currRot.forward, playerTransform.position - currRot.position, trueRot, 0.0f);
        //Debug.DrawRay(animator.gameObject.transform.position, rotDelta, Color.red);
        animator.gameObject.transform.rotation = Quaternion.LookRotation(rotDelta);

        aimingTime -= Time.deltaTime;
        if(aimingTime < 0)
        {
            animator.SetTrigger("shoot");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
