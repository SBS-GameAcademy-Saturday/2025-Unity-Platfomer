using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Experimental.AI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Damagable))]
public class FlyingEye : MonoBehaviour
{
    // 지정해준 포인트를 기준으로 Patrol한다. => 순찰
    // 플레이어가 공격 범위에 들어오면 공격한다.

    [SerializeField] private float flightSpeed = 2f;
    [SerializeField] private float waypointReachedDistance = 0.1f; // 
    [SerializeField] private List<Transform> wayPoints = new List<Transform>();

    private Animator _animator;
    private Rigidbody2D _rb;
    private Damagable _damagable;

    private Transform _currentWaypoint; // 현재 내가 이동해야할 목적지
    private int _waypointIndex = 0;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _damagable = GetComponent<Damagable>();
    }

    void Update()
    {
        Flight();
        UpdateDirection();
    }

    private void Flight()
    {
        // 이동해야할 목적지들 => 이중에서 한곳으로 이동하고 도착하면 다른 목적지로 이동
        // 1, 현재 내가 이동해야할 목적지로 이동
        if (_currentWaypoint == null)
        {
            _currentWaypoint = wayPoints[_waypointIndex];
        }
        // 이동해야할 방향
        Vector2 directionToWaypoint = (_currentWaypoint.position - transform.position).normalized;
        // 이동
        _rb.linearVelocity = directionToWaypoint * flightSpeed;

        // 2, 나와 현재 목적지와의 거리가 어느정도 가까워 지면
        //      도착했다고 판정하고 다음 목적지를 알아낸다.(순차적)
        float distance = Vector2.Distance(_currentWaypoint.position, transform.position);
        if (distance <= waypointReachedDistance)
        {
            // 3, 현재 목적지를 갱신 -> 1,
            _waypointIndex++;
            if (_waypointIndex >= wayPoints.Count)
            {
                _waypointIndex = 0;
            }
            _currentWaypoint = wayPoints[_waypointIndex];
        }
    }

    private void UpdateDirection()
    {
        if (transform.localScale.x > 0)
        {
            // 현재 오브젝트는 오른쪽을 바라보는데 왼쪽 방향으로 이동한다
            if (_rb.linearVelocityX < 0)
            {
                float newX = transform.localScale.x * -1;
                transform.localScale = new Vector3(newX, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (transform.localScale.x < 0)
        {
            // 현재 오브젝트는 왼쪽을 바라보는데 오른쪽 방향으로 이동한다
            if (_rb.linearVelocityX > 0)
            {
                float newX = transform.localScale.x * -1;
                transform.localScale = new Vector3(newX, transform.localScale.y, transform.localScale.z);
            }

        }
    }

}
