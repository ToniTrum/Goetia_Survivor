using NUnit.Framework;
using UnityEngine;
using Zenject;

public class Player : Entity<PlayerStateType>
{
    private Vector2 moveInput;
    [Inject] protected PlayerModel Model;
    private bool moving => moveInput != Vector2.zero;
    private bool dashing => Input.GetKeyDown(KeyCode.Space);

    private void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        ActionHandling();
    }

    private void ReadInput()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput = moveInput.normalized;
    }

    private void Move()
    {
        Vector2 vel = moveInput * (float)(Model.Speed * Time.deltaTime);
        Rigidbody?.MovePosition(Rigidbody.position + vel);
    }

    private void Idle()
    {
        View?.ChangeState(PlayerStateType.Idle, Animator);
    }

    private void Flip()
    {
        if (moveInput.x > 0 && !IsRightSight)
        {
            IsRightSight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput.x < 0 && IsRightSight)
        {
            IsRightSight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }


    private void ActionHandling()
    {
        if(moving)
        {
            View?.ChangeState(PlayerStateType.Walk, Animator);
            Flip();
            Move();
        }
        else
        {
            Idle();
        }
        
    }
}