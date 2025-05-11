using UnityEngine;

public class SetBoolBehaviour : StateMachineBehaviour
{
    // ��Ʈ���� Bool �Ķ���� �̸�
    public string boolParameterName;
    
    // State���� ������ �Ұ���
    public bool updateOnState;
    
    // State Machine���� ������ �� ����
    public bool updateOnStateMachine;
    
    // Enter�϶� ������ ��
    public bool valueOnEnter;
    
    // Exit�϶� ������ ��
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
