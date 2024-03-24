using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]

public class PlayerMover : MonoBehaviour
{
    private const float DistansRayCast = 0.9f;
    private const int MinCountJump = 0;
    private const int TotalJumps = 1;
    private const string Horizontal = "Horizontal";
    private const float ZeroOnX = 0;
    

    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private LayerMask _groundLayer;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D _rigidbody;

    private int _jumpsRemaining = TotalJumps;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveInput = Input.GetAxisRaw(Horizontal);

        _rigidbody.velocity = new Vector2(moveInput * _speed, _rigidbody.velocity.y);

        if (moveInput > ZeroOnX)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput < ZeroOnX)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _jumpsRemaining > MinCountJump)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _jumpsRemaining--;
        }
    }

    private void FixedUpdate()
    {
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, DistansRayCast, _groundLayer);
        
        if (isGrounded)
        {
            _jumpsRemaining = TotalJumps;
        }
    }
}
