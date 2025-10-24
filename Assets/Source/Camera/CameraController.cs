using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    public float smoothTime = 0.5f;

    Vector3 currentVelocity;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        Vector3 cameraFollow = Vector3.zero;

        if (target.position.x < -1)
        {
            cameraFollow = new Vector3(-1, 5, target.position.z);
        }
        else if(target.position.x > 3)
        {
            cameraFollow = new Vector3(3, 5, target.position.z);
        }
        else
        {
            cameraFollow = new Vector3(target.position.x,5, target.position.z);
        }

        transform.position = Vector3.SmoothDamp(
                transform.position,
                cameraFollow,
                ref currentVelocity,
                smoothTime
            );
    }


}
