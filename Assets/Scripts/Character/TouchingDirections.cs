using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    [SerializeField] private ContactFilter2D contactFilter;

    CapsuleCollider2D _touchingCollider;

    // 바닥 Cast 거리값
    [SerializeField] private float groundHitDistance = 0.05f;

    // 바닥이랑 부딫힌 결과물들
    RaycastHit2D[] _groundHits = new RaycastHit2D[5];

    // 바닥이랑 충돌했는 지 여부
    private bool _isGrounded = false;

    public bool IsGrounded
    {
        get { return _isGrounded; }
        set 
        { 
            _isGrounded = value;
            _animator.SetBool(AnimationStrings.IsGrounded, _isGrounded);
        }
    }
    // 벽 Cast 거리값
    [SerializeField] private float wallHitDistance = 0.2f;

    // 벽이랑 충돌한 결과물들
    RaycastHit2D[] _wallHits = new RaycastHit2D[5];

    // 벽이랑 충돌했는 지 여부
    private bool _isWall = false;

    public bool IsWall
    {
        get { return _isWall; }
        set { _isWall = value; }
    }

    // 벽이랑 충돌 체크해야 할 방향
    // 읽기 전용 프로퍼티(Read-Only Property)
    private Vector2 WallCheckDirection => 
        gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    private Animator _animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _touchingCollider = GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 바닥이랑 충돌했는지 여부를 계산
        IsGrounded = _touchingCollider.Cast(Vector2.down, contactFilter, _groundHits, groundHitDistance) > 0;
        IsWall = _touchingCollider.Cast(WallCheckDirection, contactFilter, _wallHits,wallHitDistance) > 0;
        Debug.Log("IsWall : " + IsWall);

    }
}
