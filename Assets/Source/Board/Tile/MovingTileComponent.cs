using UnityEngine;

public class MovingTileComponent : TileComponent
{
    [SerializeField]
    [Range(0f, 5f)]
    private float SPEED = 1f;
    [SerializeField]
    private Vector3 resetPosition;
    private float resetX;

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
        resetX = transform.position.x + maxX;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 45 == 0) { 
            transform.position += (!goingLeft) ? SPEED * Vector3.right : SPEED * Vector3.left;
        }
        attachPosition = transform.position;

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
        if (transform.position.x > resetX)
        {
            transform.position = resetPosition;
            PlayerController p;
            if ((p = GetComponentInChildren<PlayerController>()) != null) {
                p.GetComponent<LifeComponent>().DieCoffee();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + resetPosition, .75f);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position + Vector3.right * maxX, .75f);

    }
}
