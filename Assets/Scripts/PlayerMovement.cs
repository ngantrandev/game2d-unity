using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float dirX = 0f;
    private bool isPressedJump;
    public Button jump, left, right;

    [SerializeField] private LayerMask jumpableLayer;
    [SerializeField] private float jumpForce = 14f; // Giup bien private co the hien thi tren Unity Editor giong bien public nhung dam bao encapsulation
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private AudioSource jumpSoundEffect;

    private enum MovementState { idle, running, jumping, falling }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (rb.bodyType == RigidbodyType2D.Static)
        {
            return;
        }

       // DetectActivity(); // bat su kien nhan nut tren thiet bi co ban phim

        MovePlayer();

        UpdateAnimation();

    }

    private void DetectActivity()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        isPressedJump = Input.GetButtonDown("Jump");
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (isPressedJump && IsOnGround())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX < 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true;
        }
        else if (dirX > 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("player_state", (int)state);
    }

    private bool IsOnGround()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableLayer);
    }

    public void MoveLeft()
    {
        dirX = -1f;
    }

    public void MoveRight()
    {
        dirX = 1f;
    }

    public void Stop()
    {
        dirX = 0f;
    }

    public void Jump()
    {
        isPressedJump = true;
    }

    public void NotJump()
    {
        isPressedJump = false;
    }
}
