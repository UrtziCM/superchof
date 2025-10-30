using UnityEngine;
using System.Collections.Generic;
public class BoardGenerator : MonoBehaviour
{
    [System.Serializable]
    internal class Row
    {
        public GameObject rowPrefab;
        public int zSize = 1;
    }

    [SerializeField]
    private Vector3 startingPosition;
    
    private byte rowSize = 9;

    [SerializeField]
    private float topperChance = 0.05f;

    [SerializeField]
    private float grillChance = 0.075f;

    [SerializeField]
    private float iceCubeChance = 0.08f;


    [SerializeField]
    private GameObject _tilePrefab;
    private uint currentRow = 0;

    [Header("Rows")]
    [SerializeField]
    private List<Row> commonRowPrefabs = new();
    [SerializeField]
    private List<Row> steamRowPrefabs = new();
    [SerializeField]
    private List<Row> sunlightRowPrefabs = new();
    [SerializeField]
    private List<Row> coffeeRowPrefabs = new();



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateRow()
    {
        for (int i = 0; i < rowSize; i++)
        {
            GameObject instancedTile = Instantiate(_tilePrefab, startingPosition + new Vector3(i, 0, currentRow), Quaternion.identity);
            float randomValue = UnityEngine.Random.value;
            if (randomValue < topperChance)
            {
                TILE_TOP randomTopper = (TILE_TOP)UnityEngine.Random.Range(0, 4);
                instancedTile.GetComponent<TileComponent>().SetTopper(randomTopper);
            }
            else if (randomValue < grillChance)
            {
                instancedTile.GetComponent<TileComponent>().SetTopper(TILE_TOP.GRILL);
            }
            else if (randomValue < iceCubeChance)
            {
                instancedTile.GetComponent<TileComponent>().SetTopper(TILE_TOP.ICE_CUBE);
            }
        }

        currentRow++;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (int i = 0;i < rowSize;i++)
        {
            Gizmos.DrawWireCube(startingPosition + Vector3.right * i + Vector3.down, Vector3.one);
        } 
    }

}
