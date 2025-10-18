using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField]
    private Vector3 startingPosition;
    [SerializeField]
    private byte rowSize = 9;


    private GameObject tilePrefab;
    private uint currentRow = 0;


    public BoardGenerator(Vector3 startingPosition, GameObject tilePrefab) { 
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

    public void GenerateRow() {
        for (int i = 0; i < rowSize; i++)
        {
            Instantiate(tilePrefab, startingPosition + new Vector3(i, 0, currentRow), Quaternion.identity);
        }
        currentRow++;
    }


}
