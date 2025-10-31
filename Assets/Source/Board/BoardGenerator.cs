using UnityEngine;
using System.Collections.Generic;


public enum ROW_TYPE
{
    COMMON,
    ICE,
    STEAM,
    SUNLIGHT,
    COFFEE
}
public class BoardGenerator : MonoBehaviour
{
    [System.Serializable]
    internal struct RowType
    {
        [SerializeField]
        public ROW_TYPE type;
        [SerializeField]
        [Range(0f, 1f)]
        public float probability;
        public RowType(ROW_TYPE type, float probability)
        {
            this.type = type;
            this.probability = probability;
        }

    }
    [System.Serializable]
    internal class Row
    {
        public GameObject rowPrefab;
        [Range(1, 20)]
        public uint zSize = 1;
    }

    [SerializeField]
    private Vector3 startingPosition;

    private byte rowSize = 9;

    private uint currentRow = 0;


    [Header("Row types and probabilites")]
    [SerializeField]
    private List<RowType> rowProbabilities;


    [Header("Rows")]
    [SerializeField]
    private List<Row> commonRowPrefabs = new();
    [SerializeField]
    private List<Row> iceRowPrefabs = new();
    [SerializeField]
    private List<Row> steamRowPrefabs = new();
    [SerializeField]
    private List<Row> sunlightRowPrefabs = new();
    [SerializeField]
    private List<Row> coffeeRowPrefabs = new();



    void Start()
    {
        rowProbabilities.Sort((a, b) => { return b.probability.CompareTo(a.probability); });
    }

    private void OnValidate()
    {
        float rowWeightSum = 0f;
        foreach (var row in rowProbabilities)
        {
            rowWeightSum += row.probability;

        }
        if (rowWeightSum > 1f)
        {
            Debug.LogError($"BoardGenerator: Composite probability > 1.0 ({rowWeightSum})");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// Generates a row in the next position in the world.
    /// </summary>
    public void GenerateRow(ROW_TYPE row = ROW_TYPE.COMMON)
    {
        Row thisRow = null;
        switch (row)
        {
            case ROW_TYPE.COMMON:
                thisRow = commonRowPrefabs[Random.Range(0, commonRowPrefabs.Count)];
                break;
            case ROW_TYPE.ICE:
                thisRow = iceRowPrefabs[Random.Range(0, iceRowPrefabs.Count)];
                break;
            case ROW_TYPE.STEAM:
                thisRow = steamRowPrefabs[Random.Range(0, steamRowPrefabs.Count)];
                break;
            case ROW_TYPE.SUNLIGHT:
                thisRow = sunlightRowPrefabs[Random.Range(0, sunlightRowPrefabs.Count)];
                break;
            case ROW_TYPE.COFFEE:
                thisRow = coffeeRowPrefabs[Random.Range(0, coffeeRowPrefabs.Count)];
                break;
        }

        if (thisRow != null)
        {
            Instantiate(thisRow.rowPrefab, Vector3.forward * currentRow + Vector3.left * 4, Quaternion.identity);
            currentRow += thisRow.zSize;
        }


    }

    public void GenerateRandomRow()
    {
        float rndGenerationFloat = Random.value;
        float sumProbability = 0f;
        foreach (RowType rowType in rowProbabilities)
        {
            if (rndGenerationFloat < sumProbability + rowType.probability)
            {
                GenerateRow(rowType.type);
                return;
            }
            sumProbability += rowType.probability;
        }
        Debug.LogWarning("Nothing spawned");
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (int i = 0; i < rowSize; i++)
        {
            Gizmos.DrawWireCube(startingPosition + Vector3.right * i + Vector3.down, Vector3.one);
        }
    }

}
