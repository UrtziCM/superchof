using UnityEditorInternal;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    public float timeToLive = 10f;

    public bool debugIsInvincible = false;

    void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0 && !debugIsInvincible)
        {
            DieMolten();
        }
    }

    public void DieMolten() 
    {
        //Animacion
        GameManager.Instance.GameEnd();
    }

    public void DieGrill()
    {
        //Animacion
        GameManager.Instance.GameEnd();
    }

    public void DieSunlight()
    {
        //Animacion
        GameManager.Instance.GameEnd();
    }

    public void DieCoffee()
    {
        //Animacion
        GameManager.Instance.GameEnd();
    }

    public void DieSteam()
    {
        //Animacion
        GameManager.Instance.GameEnd();
    }
    public void AddTimeToLive(int time = 4) 
    {
        timeToLive += time;
        if (timeToLive > 10)
        {
            timeToLive = 10;
        }
    }
}
