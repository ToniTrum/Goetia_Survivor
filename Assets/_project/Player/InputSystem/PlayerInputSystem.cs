using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 _moveInput;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveInput.Normalize();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _moveInput*moveSpeed;
    }
}