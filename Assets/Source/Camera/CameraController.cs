using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private Vector3 offSet = new Vector3(0, 5, 0);
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
        //transform.position = target.position +  offSet;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            target.position + offSet,
            ref currentVelocity,
            smoothTime
        );
    }


}
