using Unity.Burst.CompilerServices;
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
    COFFEE = 6,
    STEAM = 7,

    // Base
    NONE = 255,
}


public class TileComponent : MonoBehaviour
{
    [SerializeField]
    private TILE_TOP TileTop;

    [SerializeField]
    public Vector3 attachPosition;

    [SerializeField]
    private GameObject[] toppers = new GameObject[6];

    public TILE_TOP GetTileTop()
    {
        return TileTop;
    }
    public void SetTileTop(TILE_TOP tile_top)
    {
        TileTop = tile_top;
        UpdateCurrentTopper();
    }

    public bool IsTraversable()
    {
        return TileTop > TILE_TOP.TONGS;
    }

    private void OnBecameVisible()
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

    private void UpdateCurrentTopper()
    {
        for (int i = 0; i < toppers.Length; i++)
        {
            if (toppers[i] != null)
                toppers[i].SetActive(false);
        }

        if ((byte)TileTop < toppers.Length)
            toppers[(int)TileTop].SetActive(true);
    }

    public void SetTopper(TILE_TOP topper)
    {
        TileTop = topper;
        UpdateCurrentTopper();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position + attachPosition, Vector3.one * .25f);
        UpdateCurrentTopper();
    }
}
