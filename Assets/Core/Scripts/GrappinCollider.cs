using UnityEngine;
public class GrappinCollider : MonoBehaviour
{

    LineRenderer line;
    TrombAddon player;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            collision.GetComponent<TrombAddon>().point = this.gameObject;
            collision.GetComponent<TrombAddon>().canGrab = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            collision.GetComponent<TrombAddon>().point = this.gameObject;
            collision.GetComponent<TrombAddon>().canGrab = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Exit player");
            collision.GetComponent<TrombAddon>().point = null;
            collision.GetComponent<TrombAddon>().canGrab = false;
        }
    }
    private void Update()
    {

    }
}
