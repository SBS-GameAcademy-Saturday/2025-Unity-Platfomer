using UnityEngine;

public class SetBoolBehaviour : StateMachineBehaviour
{
    // 컨트롤할 Bool 파라미터 이름
    public string boolParameterName;
    
    // State에서 설정을 할건지
    public bool updateOnState;
    
    // State Machine에서 설정을 할 건지
    public bool updateOnStateMachine;
    
    // Enter일때 설정할 값
    public bool valueOnEnter;
    
    // Exit일때 설정할 값
    public bool valueOnExit;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateOnState)
        {
            animator.SetBool(boolParameterName, valueOnEnter);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateOnState)
        {
            animator.SetBool(boolParameterName, valueOnExit);
        }
    }

    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        if (updateOnStateMachine)
        {
            animator.SetBool(boolParameterName, valueOnEnter);
        }
    }

    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        if (updateOnStateMachine)
        {
            animator.SetBool(boolParameterName, valueOnExit);
        }
    }
}
