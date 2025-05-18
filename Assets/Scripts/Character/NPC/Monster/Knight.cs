using UnityEngine;

public enum EMoveDirection
{
    Right,
    Left,
}

public class Knight : MonoBehaviour
{
    [SerializeField] private EMoveDirection direction;

    [SerializeField] private float walkSpeed = 3.0f;

    public float CoolTime
    {
        get { return _animator.GetFloat(AnimationStrings.CoolTime); }
        set { _animator.SetFloat(AnimationStrings.CoolTime, value); }
    }

    public EMoveDirection Direction
    {
        get { return direction; }
        set
        {
            // 방향을 갱신한다.
            direction = value;
            switch(direction)
            {
                case EMoveDirection.Left:
                    transform.localScale = new Vector3(-1, 1, 1);
                    moveDirection = Vector2.left;
                    break;
                case EMoveDirection.Right:
                    transform.localScale = new Vector3(1, 1, 1);
                    moveDirection = Vector2.right;
                    break;
            }
        }
    }



    Rigidbody2D _rb;
    Animator _animator;
    TouchingDirections _touchingDirections;
    AttackBoxZone _attackBoxZone;

    private Vector2 moveDirection = Vector2.right;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _touchingDirections = GetComponent<TouchingDirections>();
        _attackBoxZone = GetComponentInChildren<AttackBoxZone>();
        Direction = direction;
    }

    private void Update()
    {
        if(!_animator.GetBool(AnimationStrings.IsAlive))
        {
            return;
        }

        if(CoolTime > 0)
        {
            CoolTime -= Time.deltaTime;
        }

        _animator.SetBool(AnimationStrings.HasTarget, _attackBoxZone.detectionColliders.Count > 0);

        if (_touchingDirections.IsWall)
        {
            FlipDirection();
        }

        float currentSpped = _animator.GetBool(AnimationStrings.CanMove) ? walkSpeed : 0;
        _rb.linearVelocity = new Vector2(moveDirection.x * currentSpped, _rb.linearVelocityY);
    }

    private void FlipDirection()
    {
        if(Direction == EMoveDirection.Right)
        {
            Direction = EMoveDirection.Left;
        }
        else if(Direction == EMoveDirection.Left)
        {
            Direction = EMoveDirection.Right;
        }
        else
        {
            Debug.LogError("설정된 방향이 아닙니다.");
        }
    }

}
