using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveDistance;
    [SerializeField] private float moveSpeed;

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
    }

    public void MoveForward(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            targetPosition = transform.position + Vector3.forward * moveDistance;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    
    public void MoveBack(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            targetPosition = transform.position + Vector3.back * moveDistance;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    
    public void MoveLeft(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            targetPosition = transform.position + Vector3.left * moveDistance;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    
    public void MoveRight(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            targetPosition = transform.position + Vector3.right * moveDistance;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    
}
