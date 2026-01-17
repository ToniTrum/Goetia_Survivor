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
        Vector2 vel = moveInput * (float)(5.0 * Time.deltaTime);
        Rigidbody?.MovePosition(Rigidbody.position + vel);
    }

    private void Idle()
    {
        View?.ChangeState(PlayerStateType.Idle, Animator);
    }

    private void ActionHandling()
    {
        if(moving)
        {
            View?.ChangeState(PlayerStateType.Walk, Animator);
            Move();
        }
        else
        {
            Idle();
        }
        
    }
}