using UnityEngine;

public enum TILE_TOP : byte
{
    // Toppers
    SUGAR = 0,
    FORK = 1,
    SPOON = 2,
    TONGS = 3,

    // Ice cube
    ICE_CUBE = 4,

    // Dangerous
    GRILL = 5,

    // Base
    NONE = 255,
}


public class TileComponent : MonoBehaviour
{
    [SerializeField]
    private TILE_TOP TileTop { get; set; }

    [SerializeField]
    public Vector3 attachPosition;

    [SerializeField]
    private GameObject[] toppers = new GameObject[6];

    public bool IsTraversable()
    {
        return (int)TileTop < 4; // All the toppers go before 4 in the enum (haha be4) 
    }

    private void OnValidate()
    {
        UpdateCurrentTopper();
    }
    void Start()
    {
        UpdateCurrentTopper();
        attachPosition = transform.position;
    }

    void Update()
    {

    }

    private void UpdateCurrentTopper() {
        for (int i = 0; i < toppers.Length; i++)
        {
            if (toppers[i] != null)
                toppers[i].SetActive(false);
        }


        switch (TileTop)
        {
            case TILE_TOP.SUGAR:
                //toppers[(int)TILE_TOP.SUGAR].SetActive(true);
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



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(attachPosition, Vector3.one * .25f);
    }
}
