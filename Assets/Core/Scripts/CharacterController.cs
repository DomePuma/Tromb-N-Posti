using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterController : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [System.NonSerialized] protected bool canWalkOnWall = false;

    protected float horizontal;
    public float speed = 8f;
    [SerializeField] float jumpingPower = 16f;
    bool isFacingRight = true;

    private void Update() 
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if(!isFacingRight && horizontal > 0f)
        {
            Flip();
        }   
        else if(isFacingRight && horizontal < 0f)
        {
            Flip();
        }     
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded() && !canWalkOnWall)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}