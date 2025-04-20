using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // 타겟 목록들
    public List<Transform> targets;

    // 현재 내가 이동해야할 타겟
    public Transform target;
    
    // 속도값
    public float speed = 3f;

    // 순서대로 혹은 랜덤하게 이동할건지에 대한 여부
    public bool IsOrder = true;

    // 현재 타겟 인덱스
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test Script On Start");
    }

    // Update is called once per frame
    void Update()
    {
        // target의 Postion과 내 Position 을 비교해서 
        // 다르면은 target Position으로 이동한다.

        // 기본적으로 Vector는 float로 부동 소수점을 기준으로 계산이 들어간다.
        // 부동 소수점은 컴퓨터가 소수점 자리를 정확하게 계산할 수 없으므로
        // Vector끼리 비교할 때 거리나 특정 범위를 기준으로 판단한다.

        // 타겟과 자 나신의 위치(position)의 거리값을 구할 수 있습니다.
        float distance = Vector3.Distance(target.position, transform.position);

        // 거리가 0.1보다 작으면 그냥 도착했다고 가정하고 처리한다.
        if(distance < 0.1f)
        {
            // 타겟에 도착했으면 현재 타겟 목록에서 다음 타겟으로 이동하게 처리한다.
            // bool 변수를 public으로 만들어서 True면 순서대로, False면 랜덤하게 이동하도록 한다.
            // -> 순서대로 이동한다.
            // -> 랜덤하게 이동한다.
            if (IsOrder)
            {
                // 순서대로 이동하기 위해서는 현재 이동할 인덱스를 가지고 있어야 합니다.
                currentIndex++;
                if(currentIndex >= targets.Count)
                {
                    currentIndex = 0;
                }
                target = targets[currentIndex];
            }
            else
            {
                // 0~ targets.Count 까지 중 랜덤한 숫자를 반환한다.
                int randomIndex = Random.Range(0, targets.Count);
                target = targets[randomIndex];
            }
            
            Debug.Log("타겟 위치에 도착했습니다.");

        }
        else
        {
            // 내가 타겟의 위치로 이동한다.
            // => 타겟 위치로 가능 방향
            // 타겟 위치에서 나의 위치를 빼고 normalize 한다.
            Vector3 direcition = target.position - transform.position;

            // 현재 나의 위치에서 타겟 위치로 가는 방향을 더해준다.
            transform.position += direcition.normalized * Time.deltaTime * speed;
        }
    }
}
