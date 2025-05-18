using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Property(프로퍼티)
    // 프로퍼티란?
    // C#에서 클래스의 멤버 변수(필드)에 대한 접근을 제어하는 방법을 제공하는 기능입니다.
    // 프로퍼티를 사용하면 필드에 대한 읽기와 쓰기(데이터 수정)을 캡슐화하여
    // 필드 값에 대한 유효성 검사 혹은 다른 로직을 실행할 수 있게 해줍니다.
    [SerializeField] private float walkSpeed = 3;
    [SerializeField] private float sprintSpeed = 6;
    [SerializeField] private float jumpPower = 10;
    [SerializeField] private int maxJumpCount = 1;

    // _isMoving 필드 값
    private bool _isMoving = false;

    // _isMoving에 대한 프로퍼티
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        set
        {
            _isMoving = value;
            _animator.SetBool(AnimationStrings.IsMoving, _isMoving);
        }
    }
    // isSprint 필드 값
    private bool _isSprint = false;

    // isSprint에 대한 프로퍼티
    public bool IsSprint
    {
        // 프로퍼티에는 get, set 키워드가 있습니다.
        // get => 멤버 변수(필드)의 값을 가져오는 키워드
        // set => 멤버 변수(필드)의 값을 수정하는 키워드
        get
        {
            // get에는 무조건 return 키워드가 있어야 합니다.
            return _isSprint;
        }
        set
        {
            // set에는 무조건 필드 = value 키워드를 통해서 바꿀 려고 하는 value값을 갱신해줘야 한다.
            _isSprint = value;
            _animator.SetBool(AnimationStrings.IsSprint, _isSprint);
        }
    }

    private Vector2 _inputDirection = Vector2.zero;
    private int _currentJumpCount = 0;

    Rigidbody2D _rb;
    Animator _animator;
    TouchingDirections _touchingDirections;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _touchingDirections = GetComponent<TouchingDirections>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_animator.GetBool(AnimationStrings.IsAlive))
        {
            return;
        }

        if(_rb.linearVelocityY < 0 && _touchingDirections.IsGrounded)
        {
            _currentJumpCount = 0;
        }
        // Unity 5 : _rb.velocity.y
        _animator.SetFloat(AnimationStrings.yVelocity, _rb.linearVelocity.y);
        float currentSpeed = IsSprint ? sprintSpeed : walkSpeed;
        currentSpeed = _touchingDirections.IsWall ? 0 : currentSpeed;

        currentSpeed = _animator.GetBool(AnimationStrings.CanMove) ? currentSpeed : 0;
        _rb.linearVelocity = new Vector2(_inputDirection.x * currentSpeed, _rb.linearVelocity.y);
    }

    public void OnMoveInput(InputAction.CallbackContext callback)
    {
        _inputDirection = callback.ReadValue<Vector2>();
        IsMoving = _inputDirection != Vector2.zero;
        OnSetDirection();
    }

    private void OnSetDirection()
    {
        if (transform.localScale.x > 0 && _inputDirection.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else if(transform.localScale.x <0 && _inputDirection.x > 0)
        {
            transform.localScale = new Vector3(1,1, 1);
        }
    }

    public void OnSprintInput(InputAction.CallbackContext callback)
    {
        if(callback.started)
        {
            IsSprint = true;
            
        }
        else if(callback.canceled)
        {
            IsSprint = false;
        }
    }

    // 2단 혹은 3단 혹은 단일 점프 기능 구현
    public void OnJumpInput(InputAction.CallbackContext callback)
    {
        if (callback.started && _currentJumpCount < maxJumpCount)
        {
            _animator.SetTrigger(AnimationStrings.Jump);

            _currentJumpCount++;
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpPower);
        }
    }

    public void OnGroundAttackInput(InputAction.CallbackContext callback)
    {
        if(callback.started)
        {
            _animator.SetTrigger(AnimationStrings.Attack);

        }
    }
}