using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveDistance;
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private bool debugIsInvincible = false;

    private Vector3 targetPosition;

    private LifeComponent lifeComponentInstance;

    private void Start()
    {
        targetPosition = transform.position;

        lifeComponentInstance = GetComponent<LifeComponent>();
    }

    public void MoveForward(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            CheckAndMove(Vector3.forward);
            GameManager.Instance.TryAddScore();
        }
    }

    public void MoveBack(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            CheckAndMove(Vector3.back);
        }
    }

    public void MoveLeft(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            CheckAndMove(Vector3.left);
        }
    }

    public void MoveRight(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            CheckAndMove(Vector3.right);
        }
    }

    private void CheckAndMove(Vector3 direction)
    {
        Vector3 boxPos = transform.position + direction;
        Collider[] hitCollider = Physics.OverlapBox(boxPos, transform.localScale * 0.25f, Quaternion.identity);
        foreach (Collider col in hitCollider)
        {
            TileComponent tile = col.gameObject.GetComponent<TileComponent>();
            if (tile != null && tile.IsTraversable())
            {
                transform.position = tile.attachPosition;
                switch (tile.GetTileTop())
                {
                    case TILE_TOP.GRILL:
                        lifeComponentInstance.DieGrill();
                        break;
                    case TILE_TOP.ICE_CUBE:
                        lifeComponentInstance.AddTimeToLive();
                        tile.SetTileTop(TILE_TOP.NONE);
                        break;
                }
                transform.SetParent(tile.transform);
            }
        }
    }

    void OnDrawGizmos()
    {
        Vector3 boxforward = transform.position + Vector3.forward;
        Vector3 boxback = transform.position + Vector3.back;
        Vector3 boxleft = transform.position + Vector3.left;
        Vector3 boxright = transform.position + Vector3.right;
        Gizmos.color = Color.red;
        // Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (Application.isPlaying)
        {
            // Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(boxforward, transform.localScale * 0.25f);
            Gizmos.DrawWireCube(boxback, transform.localScale * 0.25f);
            Gizmos.DrawWireCube(boxleft, transform.localScale * 0.25f);
            Gizmos.DrawWireCube(boxright, transform.localScale * 0.25f);
        }
    }
}
