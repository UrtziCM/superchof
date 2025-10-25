using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveDistance;
    [SerializeField]
    private float moveSpeed;

    private LifeComponent lifeComponentInstance;

    private const float MINIMUM_SWIPE_MAGNITUDE = 5f;

    [SerializeField]
    private InputAction position, press;

    private Vector2 initialPos;
    private Vector2 currentPos => position.ReadValue<Vector2>();

    private void Awake()
    {
        position.Enable();
        press.Enable();
        press.performed += _callbackContext => { initialPos = currentPos; };
        press.canceled += _callbackContext => { DetectSwipe(); };
    }

    private void Start()
    {
        lifeComponentInstance = GetComponent<LifeComponent>();
    }

    private void DetectSwipe()
    {
        Vector2 delta = (currentPos - initialPos);
        Vector2 direction = Vector2.zero;
        if (Math.Abs(delta.x) > MINIMUM_SWIPE_MAGNITUDE && Math.Abs(delta.x) > Math.Abs(delta.y))
        {
            direction.x = delta.x > 0 ? 1 : -1;
        }
        else if (Math.Abs(delta.y) > MINIMUM_SWIPE_MAGNITUDE)
        {
            direction.y = delta.y > 0? 1 : -1;


        }
        Debug.Log(direction);
        direction = direction.normalized;
        Vector3 threeDirection = new(direction.x, 0, direction.y);
        CheckAndMove(threeDirection);
    }

    //public void Tap(InputAction.CallbackContext callbackContext)
    //{
    //    if (callbackContext.canceled)
    //    {
    //        CheckAndMove(Vector3.forward);
    //        GameManager.Instance.TryAddScore();
    //    }
    //}
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
