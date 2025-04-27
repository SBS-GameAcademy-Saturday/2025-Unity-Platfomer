using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 3;
    public float sprintSpeed = 6;
    public float jumpPower = 10;
    Vector2 inputDirection = Vector2.zero;

    private bool isSprint = false;

    Rigidbody2D rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = isSprint ? sprintSpeed : walkSpeed;
        rb.velocity = new Vector2(inputDirection.x * currentSpeed, rb.velocity.y);
    }

    public void OnMoveInput(InputAction.CallbackContext callback)
    {
        inputDirection = callback.ReadValue<Vector2>();
        animator.SetBool(AnimationStrings.IsMoving, inputDirection != Vector2.zero);
        OnSetDirection();
    }

    private void OnSetDirection()
    {
        if (transform.localScale.x > 0 && inputDirection.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else if(transform.localScale.x <0 && inputDirection.x > 0)
        {
            transform.localScale = new Vector3(1,1, 1);
        }
    }

    public void OnSpringInput(InputAction.CallbackContext callback)
    {
        if(callback.started)
        {
            isSprint = true;
            animator.SetBool(AnimationStrings.IsSprint,true);
        }
        else if(callback.canceled)
        {
            isSprint = false;
            animator.SetBool(AnimationStrings.IsSprint, false);
        }
    }
    
    public void OnJumpInput(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }


}
