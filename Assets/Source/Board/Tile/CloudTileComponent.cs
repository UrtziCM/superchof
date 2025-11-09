using Unity.VisualScripting;
using UnityEngine;

public class CloudTileComponent : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 5f)]
    private float SPEED = 2f;
    [SerializeField]
    private bool goingLeft = false;
    [SerializeField]
    private Vector3 resetPosition;

    private void Start()
    {
        resetPosition = transform.TransformPoint(resetPosition);
    }

    void Update()
    {
        if (!goingLeft)
        {
            transform.position += SPEED * Time.deltaTime * Vector3.right;
        }
        else
        {
            transform.position += SPEED * Time.deltaTime * Vector3.left;
        }
    }
    private void LateUpdate()
    {
        if (transform.position.x > 4)
        {
            transform.position = resetPosition;
        }
    }
}
