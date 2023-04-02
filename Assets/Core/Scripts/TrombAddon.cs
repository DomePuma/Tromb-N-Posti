using UnityEngine;
using UnityEngine.InputSystem;
public class TrombAddon : CharacterController
{
    [SerializeField] LineRenderer grappin;
    [System.NonSerialized] public GameObject point;
    bool isAttached = false;
    [System.NonSerialized] public bool canGrab = false;

    public void Grab(InputAction.CallbackContext context)
    {
        if(context.started && isAttached == false && canGrab == true)
        {
            grappin.positionCount = 2;
            grappin.SetPosition(0, this.gameObject.transform.position);
            grappin.SetPosition(1, point.transform.position);
            isAttached = true;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        
    }
    public void GoToGrab(InputAction.CallbackContext context)
    {
        if(context.started && isAttached == true && canGrab == true)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, point.transform.position + new Vector3(0,1,0), 1000);
            isAttached = false;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            grappin.positionCount = 0;
        }
    }
    public void UnGrab(InputAction.CallbackContext context)
    {
        if(context.started && isAttached == true && canGrab == true)
        {
            isAttached = false;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            grappin.positionCount = 0;

        }
    }
    new public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}