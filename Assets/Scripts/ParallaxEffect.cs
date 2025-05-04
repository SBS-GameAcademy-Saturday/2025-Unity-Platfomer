using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    // ī�޶� 
    [SerializeField] private Camera camera;

    // �÷��̾� ��ġ
    [SerializeField] private Transform followTarget;

    [SerializeField] private float parallaxFactor = 1.1f;


    // ���� ��ġ
    Vector2 startingPosition;

    // ������ ���۵ǰ� ���� ī�޶� �����̴� ����
    Vector2 camMoveSinceStart => (Vector2)camera.transform.position - startingPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // camMoveSinceStart.x = 5
        // parallaxFactor = 1.1
        Vector2 newPosition = startingPosition + camMoveSinceStart / -parallaxFactor;

        transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);
    }
}
