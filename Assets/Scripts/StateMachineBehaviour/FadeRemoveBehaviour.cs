using System.Net.NetworkInformation;
using UnityEngine;

public class FadeRemoveBehaviour : StateMachineBehaviour
{
    [SerializeField] private float fadeTime = 0.5f;
    [SerializeField] private float fadeDelay = 0;

    private float timerElapsed = 0; // Fade Time 시간이 지났는지 체크하기 위한 변수
    private float fadeDelayElapsed = 0;// Fade Delay Time 시간이 지났는지 체크하기 위한 변수

    SpriteRenderer spriteRenderer;
    GameObject objToRemove;
    Color startColor;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timerElapsed = 0f;
        spriteRenderer = animator.GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        objToRemove = animator.gameObject;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 딜레이 시간이 있는지
        if (fadeDelay > fadeDelayElapsed)
        {
            // 아직 딜레이 시간이 남아있으면 계속 DeltaTime 값만큼 더해준다.
            fadeDelayElapsed += Time.deltaTime;
        }
        else
        {
            timerElapsed += Time.deltaTime;

            float newAlpha = startColor.a * (1 - (timerElapsed / fadeTime));

            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);
            
            if(timerElapsed > fadeTime)
            {
                Destroy(objToRemove);
            }
        }
    }
}
