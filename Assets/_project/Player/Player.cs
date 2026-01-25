using UnityEngine;
using Zenject;

public class Player : Entity<PlayerStateType>
{
    private Vector2 moveInput;
    [Inject] protected PlayerModel Model;

    [SerializeField] HealthBar healthBar;
    [SerializeField] GoldBar goldBar;
    [SerializeField] StaminaBar staminaBar;

    private bool moving => moveInput != Vector2.zero;
    private float dashEndTime = 0f;
    private float lastDashTime = 0f;
    private float lastHealthRegenTime = 0f;
    private float lastStaminaRegenTime = 0f;
    private bool isDashing = false;
    private Vector2 dashDirection;

    private void Start()
    {
        healthBar.Subscribe(Model);
        goldBar.Subscribe(Model);
        staminaBar.Subscribe(Model);

        lastHealthRegenTime = Time.time;
        lastStaminaRegenTime = Time.time;
    }

    private void Update()
    {
        ReadInput();
        HandleRegeneration();

       
        if (Input.GetKeyDown(KeyCode.Space))
            StartDash();
    }

    private void FixedUpdate()
    {
        
        if (isDashing)
        {
            Vector2 velocity = dashDirection * Model.DashSpeed * Time.fixedDeltaTime;
            Rigidbody.MovePosition(Rigidbody.position + velocity);

            if (Time.time >= dashEndTime)
                isDashing = false;
        }
        else
        {
            ActionHandling();
        }
    }

    private void ReadInput()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void Move()
    {
        Vector2 vel = moveInput * (float)(Model.Speed * Time.deltaTime);
        Rigidbody?.MovePosition(Rigidbody.position + vel);
    }

    private void StartDash()
    {
        if (Time.time < lastDashTime + Model.DashCooldown || 
            moveInput == Vector2.zero || Model.Stamina < Model.DashCost)
            return;

        Model.Stamina -= Model.DashCost;

        isDashing = true;
        dashEndTime = Time.time + Model.DashDuration;
        lastDashTime = Time.time;
        dashDirection = moveInput;

        View?.ChangeState(PlayerStateType.Dash, Animator);
    }

    private void HandleRegeneration()
    {
        if (Model.HealthRegeneration > 0 && Model.Health < Model.MaxHealth)
        {
            if (Time.time >= lastHealthRegenTime + PlayerModel.HEALTH_REGEN_INTERVAL)
            {
                Model.RegenerateHealth();
                lastHealthRegenTime = Time.time;
            }
        }
        
        if (!isDashing && Model.StaminaRegeneration > 0 && Model.Stamina < Model.MaxStamina)
        {
            if (Time.time >= lastStaminaRegenTime + PlayerModel.STAMINA_REGEN_INTERVAL)
            {
                Model.RegenerateStamina();
                lastStaminaRegenTime = Time.time;
            }
        }
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
