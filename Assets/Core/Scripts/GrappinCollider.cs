using UnityEngine;

public class GrappinCollider : MonoBehaviour
{
    TrombAddon player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            player = collision.GetComponent<TrombAddon>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Exit player");
            player = null;
        }
    }
}
