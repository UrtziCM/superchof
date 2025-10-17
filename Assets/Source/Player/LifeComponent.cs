using UnityEditorInternal;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    [SerializeField] 
    private float timeToLive = 15f;

    [SerializeField]
    private float timeRecover;

    void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
        {
            TimeKill();
        }
    }

    private void TimeKill()
    {
        //Animacion de morir por tiempo
        GameManager.Instance.GameEnd();
    }

    public void RedKill() 
    {
        //Animacion de morir por casilla
        GameManager.Instance.GameEnd();
    }

    public void PickIceCube() 
    {
        timeToLive = timeToLive + timeRecover;
    }
}
