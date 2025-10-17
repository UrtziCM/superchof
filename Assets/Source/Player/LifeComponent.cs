using UnityEditorInternal;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    [SerializeField]
    private float timeToLive = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToLive -= Time.deltaTime;
    }

    
}
