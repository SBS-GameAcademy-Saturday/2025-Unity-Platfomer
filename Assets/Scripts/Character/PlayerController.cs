using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Property(������Ƽ)
    // ������Ƽ��?
    // C#���� Ŭ������ ��� ����(�ʵ�)�� ���� ������ �����ϴ� ����� �����ϴ� ����Դϴ�.
    // ������Ƽ�� ����ϸ� �ʵ忡 ���� �б�� ����(������ ����)�� ĸ��ȭ�Ͽ�
    // �ʵ� ���� ���� ��ȿ�� �˻� Ȥ�� �ٸ� ������ ������ �� �ְ� ���ݴϴ�.
    [SerializeField] private float walkSpeed = 3;
    [SerializeField] private float sprintSpeed = 6;
    [SerializeField] private float jumpPower = 10;
    [SerializeField] private int maxJumpCount = 1;

    // _isMoving �ʵ� ��
    private bool _isMoving = false;

    // _isMoving�� ���� ������Ƽ
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
    // isSprint �ʵ� ��
    private bool _isSprint = false;

    // isSprint�� ���� ������Ƽ
    public bool IsSprint
    {
        // ������Ƽ���� get, set Ű���尡 �ֽ��ϴ�.
        // get => ��� ����(�ʵ�)�� ���� �������� Ű����
        // set => ��� ����(�ʵ�)�� ���� �����ϴ� Ű����
        get
        {
            // get���� ������ return Ű���尡 �־�� �մϴ�.
            return _isSprint;
        }
        set
        {
            // set���� ������ �ʵ� = value Ű���带 ���ؼ� �ٲ� ���� �ϴ� value���� ��������� �Ѵ�.
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

    // 2�� Ȥ�� 3�� Ȥ�� ���� ���� ��� ����
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