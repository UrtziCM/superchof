using UnityEngine;

public class MovingTileComponent : TileComponent
{
    [SerializeField]
    [Range(0f, 5f)]
    private float SPEED = 2f;
    [SerializeField]
    private Vector3 resetPosition;
    [SerializeField]
    [Range(-15,15)]
    private ushort maxX = 9;
    [SerializeField]
    [Range(-15,15)]
    private short minX = -1;

    [SerializeField]
    private bool goingLeft = false;
    
    void Start()
    {
        resetPosition = transform.TransformPoint(resetPosition);
    }

    // Update is called once per frame
    void Update()
    {
        attachPosition = transform.position;

        transform.position +=(!goingLeft)? SPEED * Time.deltaTime * Vector3.right: SPEED * Time.deltaTime * Vector3.left;
        //if (!goingLeft)
        //{
        

        //} 
        //else
        //{
        //    if ((short)transform.position.x < minX)
        //    {
        //        transform.position = resetPosition;
        //    }
        //}
    }

    private void LateUpdate()
    {
        if (transform.position.x > 4)
        {
            transform.position = resetPosition;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + resetPosition, Vector3.one);
    }
}
