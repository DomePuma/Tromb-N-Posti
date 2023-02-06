using UnityEngine;

public class PostiAddon : MonoBehaviour
{
    Rigidbody2D rb;
    float vertical;
    CharacterController controllerScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controllerScript = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveOnWall();
    }
    void MoveOnWall()
    {
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Vertical") && controllerScript.canWalkOnWall == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, vertical * controllerScript.speed);
        }
        if (Input.GetButtonUp("Vertical") && controllerScript.canWalkOnWall == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            rb.gravityScale = 0;
            controllerScript.canWalkOnWall = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            controllerScript.canWalkOnWall = false;
            rb.gravityScale = 1;
        }
    }
}
