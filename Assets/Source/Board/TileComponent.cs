using UnityEngine;

public enum TILE_TOP : byte
{
    // Toppers
    SUGAR = 0,
    FORK = 1,
    SPOON = 2,
    TONGS = 3,

    // Ice cube
    ICE_CUBE = 44,

    // Dangerous
    GRILL = 100,

    // Base
    NONE = 255,
}


public class TileComponent : MonoBehaviour
{
    [SerializeField]
    private TILE_TOP tileTop;

    [SerializeField]
    private Vector3 attachPosition;

    public bool IsTraversable()
    {
        return (int)tileTop < 4; // All the toppers go before 4 in the enum (haha be4) 
    }

    private void OnValidate()
    {
        // Change model in editor goes here
    }
    void Start()
    {
        switch (tileTop)
        {
            case TILE_TOP.SUGAR:
                break;
            case TILE_TOP.FORK:
                break;
            case TILE_TOP.TONGS:
                break;
            case TILE_TOP.SPOON:
                break;

            case TILE_TOP.ICE_CUBE:
                break;

            case TILE_TOP.GRILL:
                break;
            default:
                break;
        }
    }

    void Update()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position + attachPosition, Vector3.one * .25f);
    }
}
