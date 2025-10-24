using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField]
    private Vector3 startingPosition;
    [SerializeField]
    private byte rowSize = 9;

    [SerializeField]
    private float topperChance = 0.05f;

    [SerializeField]
    private float grillChance = 0.075f;



    private GameObject tilePrefab;
    private uint currentRow = 0;


    public BoardGenerator(Vector3 startingPosition, GameObject tilePrefab)
    {
        this.startingPosition = startingPosition;
        this.tilePrefab = tilePrefab;
    }

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
            GameObject instancedTile = Instantiate(tilePrefab, startingPosition + new Vector3(i, 0, currentRow), Quaternion.identity);
            float randomValue = Random.value;
            if (randomValue < topperChance)
            {
                TILE_TOP randomTopper = (TILE_TOP)Random.Range(0, 4);
                instancedTile.GetComponent<TileComponent>().SetTopper(randomTopper);
            }
            else if (randomValue < grillChance)
            {
                instancedTile.GetComponent<TileComponent>().SetTopper(TILE_TOP.GRILL);
            }
        }

        currentRow++;
    }


}
