using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float moveDistance;
    [SerializeField] 
    private float moveSpeed;

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
    }

    public void MoveForward(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Vector3 pos = transform.position;
            Vector2 PositionToMove = new Vector2(pos.x, pos.z++);
            //Consigo la casilla del board manager
            //Pregunto a la casilla si se puede mover

        }
    }
    
    public void MoveBack(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Vector3 pos = transform.position;
            Vector2 PositionToMove = new Vector2(pos.x, pos.z--);
            //Consigo la casilla del board manager
            //Pregunto a la casilla si se puede mover
        }
    }
    
    public void MoveLeft(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Vector3 pos = transform.position;
            Vector2 PositionToMove = new Vector2(pos.x--, pos.z);
            //Consigo la casilla del board manager
            //Pregunto a la casilla si se puede mover
        }
    }
    
    public void MoveRight(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Vector3 pos = transform.position;
            Vector2 PositionToMove = new Vector2(pos.x++, pos.z);
            //Consigo la casilla del board manager
            //Pregunto a la casilla si se puede mover
        }
    }
    
}
