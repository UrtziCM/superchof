using Unity.VisualScripting;
using UnityEngine;

public class CloudTileComponent : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 5f)]
    private float secondsToMove = 0.2f;
    private float time;
    [SerializeField]
    private Vector3 resetPosition;

    private void Start()
    {
        resetPosition = transform.TransformPoint(resetPosition);
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= secondsToMove)
        {
            time = 0f;
            transform.position += transform.right * 1;
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
