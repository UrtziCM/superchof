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

    [SerializeField]
    private bool goingLeft = false;

    private int direction;

    private void Start()
    {
        resetPosition = transform.TransformPoint(resetPosition);
        time = 0f;

        direction = goingLeft ? -1 : 1;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= secondsToMove)
        {
            time = 0f;
            transform.position += transform.right * direction;
        }
    }
    private void LateUpdate()
    {
        if (!goingLeft)
        {
            if (transform.position.x > 13) {
                transform.position = resetPosition;
            }
        }
        else
        {
            if (transform.position.x < -13)
            {
                transform.position = resetPosition;
            }
        }
    }
}
