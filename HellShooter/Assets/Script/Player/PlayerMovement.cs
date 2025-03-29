using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float xInput;
    bool canJump;

    public Transform groundCheckPos;
    public LayerMask groundLayer;

    [Header("Player Stats")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Hidden Stats")]
    public float fallMultiplier;
    public float lowJumpMultiplier;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Sideways Input
        xInput = Input.GetAxisRaw("Horizontal");

        //Detect Ground
        DetectGround();

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        //Better Jumping
        if(rb.linearVelocityY < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }else if(rb.linearVelocityY > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        //Input
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocityY);
    }

    private void DetectGround()
    {
        canJump = Physics2D.OverlapCircle(groundCheckPos.position, 0.5f, groundLayer);
    }
}
