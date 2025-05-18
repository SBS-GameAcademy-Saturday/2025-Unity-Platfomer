using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    [SerializeField] private ContactFilter2D contactFilter;

    CapsuleCollider2D _touchingCollider;

    // �ٴ� Cast �Ÿ���
    [SerializeField] private float groundHitDistance = 0.05f;

    // �ٴ��̶� �΋H�� �������
    RaycastHit2D[] _groundHits = new RaycastHit2D[5];

    // �ٴ��̶� �浹�ߴ� �� ����
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
    // �� Cast �Ÿ���
    [SerializeField] private float wallHitDistance = 0.2f;

    // ���̶� �浹�� �������
    RaycastHit2D[] _wallHits = new RaycastHit2D[5];

    // ���̶� �浹�ߴ� �� ����
    private bool _isWall = false;

    public bool IsWall
    {
        get { return _isWall; }
        set { _isWall = value; }
    }

    // ���̶� �浹 üũ�ؾ� �� ����
    // �б� ���� ������Ƽ(Read-Only Property)
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
        // �ٴ��̶� �浹�ߴ��� ���θ� ���
        IsGrounded = _touchingCollider.Cast(Vector2.down, contactFilter, _groundHits, groundHitDistance) > 0;
        IsWall = _touchingCollider.Cast(WallCheckDirection, contactFilter, _wallHits,wallHitDistance) > 0;
        Debug.Log("IsWall : " + IsWall);

    }
}
