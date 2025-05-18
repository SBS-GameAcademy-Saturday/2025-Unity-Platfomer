using UnityEngine;

public class PlayOneShotBehaviour : StateMachineBehaviour
{
    public AudioClip clip;
    public float volume = 1.0f;
    public bool playOnEnter;
    public bool playOnUpdate;
    public bool playOnExit;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(playOnEnter)
        {
            AudioSource.PlayClipAtPoint(clip,animator.gameObject.transform.position,volume);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(playOnExit)
        {
            AudioSource.PlayClipAtPoint(clip, animator.gameObject.transform.position, volume);
        }
    }
}
