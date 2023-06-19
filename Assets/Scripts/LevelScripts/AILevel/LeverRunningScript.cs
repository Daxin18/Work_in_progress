using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LeverRunningScript : StateMachineBehaviour
{
    public float leverSpeed = 5f;
    private GameObject lever;
    private GameObject player;
    private bool alreadySaid = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lever = GameObject.Find("AILever");
        player = GameObject.Find("Player");
        Vector2 direction = lever.transform.position - player.transform.position;
        lever.GetComponent<Rigidbody2D>().velocity = direction.normalized * leverSpeed;
        if (!alreadySaid)
        {
            NarratorManager narrator = GameObject.Find("NarratorManager").GetComponent<NarratorManager>();
            narrator.Say("FirstRun");
            alreadySaid = true;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 direction = lever.transform.position - player.transform.position;
        lever.GetComponent<Rigidbody2D>().velocity = direction.normalized * leverSpeed;
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
