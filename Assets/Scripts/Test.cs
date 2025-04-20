using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Ÿ�� ��ϵ�
    public List<Transform> targets;

    // ���� ���� �̵��ؾ��� Ÿ��
    public Transform target;
    
    // �ӵ���
    public float speed = 3f;

    // ������� Ȥ�� �����ϰ� �̵��Ұ����� ���� ����
    public bool IsOrder = true;

    // ���� Ÿ�� �ε���
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test Script On Start");
    }

    // Update is called once per frame
    void Update()
    {
        // target�� Postion�� �� Position �� ���ؼ� 
        // �ٸ����� target Position���� �̵��Ѵ�.

        // �⺻������ Vector�� float�� �ε� �Ҽ����� �������� ����� ����.
        // �ε� �Ҽ����� ��ǻ�Ͱ� �Ҽ��� �ڸ��� ��Ȯ�ϰ� ����� �� �����Ƿ�
        // Vector���� ���� �� �Ÿ��� Ư�� ������ �������� �Ǵ��Ѵ�.

        // Ÿ�ٰ� �� ������ ��ġ(position)�� �Ÿ����� ���� �� �ֽ��ϴ�.
        float distance = Vector3.Distance(target.position, transform.position);

        // �Ÿ��� 0.1���� ������ �׳� �����ߴٰ� �����ϰ� ó���Ѵ�.
        if(distance < 0.1f)
        {
            // Ÿ�ٿ� ���������� ���� Ÿ�� ��Ͽ��� ���� Ÿ������ �̵��ϰ� ó���Ѵ�.
            // bool ������ public���� ���� True�� �������, False�� �����ϰ� �̵��ϵ��� �Ѵ�.
            // -> ������� �̵��Ѵ�.
            // -> �����ϰ� �̵��Ѵ�.
            if (IsOrder)
            {
                // ������� �̵��ϱ� ���ؼ��� ���� �̵��� �ε����� ������ �־�� �մϴ�.
                currentIndex++;
                if(currentIndex >= targets.Count)
                {
                    currentIndex = 0;
                }
                target = targets[currentIndex];
            }
            else
            {
                // 0~ targets.Count ���� �� ������ ���ڸ� ��ȯ�Ѵ�.
                int randomIndex = Random.Range(0, targets.Count);
                target = targets[randomIndex];
            }
            
            Debug.Log("Ÿ�� ��ġ�� �����߽��ϴ�.");

        }
        else
        {
            // ���� Ÿ���� ��ġ�� �̵��Ѵ�.
            // => Ÿ�� ��ġ�� ���� ����
            // Ÿ�� ��ġ���� ���� ��ġ�� ���� normalize �Ѵ�.
            Vector3 direcition = target.position - transform.position;

            // ���� ���� ��ġ���� Ÿ�� ��ġ�� ���� ������ �����ش�.
            transform.position += direcition.normalized * Time.deltaTime * speed;
        }
    }
}
