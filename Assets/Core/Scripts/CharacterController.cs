using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] public float speed = 8f;
    [SerializeField] float jumpingPower = 16f;
    
    [System.NonSerialized] public bool canWalkOnWall = false;
    float horizontal;
    bool isFacingRight = true;
    bool isGrounded = true;
    Rigidbody2D rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded && !canWalkOnWall)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            isGrounded = false;
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}