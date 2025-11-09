using Unity.VisualScripting;
using UnityEngine;

public class SunBeamTileComponent : MonoBehaviour
{
    [SerializeField]
    private Material redMaterial;
    [SerializeField] 
    private Material whiteMaterial;
    
    private Transform floorTile;

    void Start()
    {
        RaycastHit hitFloor;
        if (Physics.Raycast(transform.position - Vector3.up * 4, Vector3.down * 12, out hitFloor))
        {
            floorTile = hitFloor.transform;
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down * 12, out hit))
        {
            Transform Tilehit = hit.transform;
            if (Tilehit.TryGetComponent<CloudTileComponent>(out CloudTileComponent component))
            {
                floorTile.GetComponent<TileComponent>().SetTileTop(TILE_TOP.NONE);
                floorTile.GetComponentInChildren<MeshRenderer>().material = whiteMaterial;
            }
            else
            {
                Tilehit.GetComponent<TileComponent>().SetTileTop(TILE_TOP.SUNLIGHT);
                Tilehit.GetComponentInChildren<MeshRenderer>().material = redMaterial;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down*12);
    }
}
