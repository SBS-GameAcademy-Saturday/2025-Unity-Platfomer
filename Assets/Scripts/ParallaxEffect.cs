using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    // 카메라 
    [SerializeField] private Camera camera;

    // 플레이어 위치
    [SerializeField] private Transform followTarget;

    [SerializeField] private float parallaxFactor = 1.1f;


    // 시작 위치
    Vector2 startingPosition;

    // 게임이 시작되고 나서 카메라가 움직이는 방향
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
