using UnityEngine;

public class MovingTileComponent : TileComponent
{
    private Vector3 startingPosition;

    [SerializeField]
    [Range(0f, 5f)]
    private float SPEED = 2f;

    [SerializeField]
    private float maxDistance = 14f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        attachPosition = transform.position;

        transform.position += SPEED * Time.deltaTime * Vector3.right;
        if ((transform.position - startingPosition).sqrMagnitude > maxDistance * maxDistance)
        {
            transform.position = startingPosition;
        }
    }
}
