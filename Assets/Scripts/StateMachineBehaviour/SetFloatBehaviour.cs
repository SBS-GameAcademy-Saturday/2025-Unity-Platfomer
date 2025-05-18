using UnityEngine;
using UnityEngine.Animations;

public class SetFloatBehaviour : StateMachineBehaviour
{
    public string floatParameterName;

    /// <summary>
    /// �� State�� ������ �� �� ������ ���� ����
    /// </summary>
    public bool updateOnStateEnter;

    /// <summary>
    /// �� State�� ������ �� �� ������ ���� ����
    /// </summary>
    public bool updateOnStateExit;

    public bool updateOnStateMachineEnter;

    public bool updateOnStateMachineExit;

    public float valueOnEnter;

    public float valueOnExit;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(updateOnStateEnter)
        {
            animator.SetFloat(floatParameterName, valueOnEnter);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(updateOnStateExit)
        {
            animator.SetFloat(floatParameterName, valueOnExit);
        }
    }

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        if(updateOnStateMachineEnter)
        {
            animator.SetFloat(floatParameterName, valueOnEnter);
        }
    }

    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        if (updateOnStateMachineExit)
        {
            animator.SetFloat(floatParameterName, valueOnExit);
        }
    }

}
