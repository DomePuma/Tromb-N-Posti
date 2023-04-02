using UnityEngine;
using UnityEngine.InputSystem;
public class PostiAddon : CharacterController
{
    float vertical;

    new private void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
        if(canWalkOnWall && vertical > 0f || vertical < 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        if(canWalkOnWall && vertical == 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            rb.gravityScale = 0;
            canWalkOnWall = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            canWalkOnWall = false;
            rb.gravityScale = 1;
        }
    }
}