using UnityEditorInternal;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    [SerializeField]
    private HPCanvasHelper _hpCanvasHelper;

    public float timeToLive = 10f;

    public bool debugIsInvincible = false;

    void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0 && !debugIsInvincible)
        {
            DieMolten();
        }
        _hpCanvasHelper.SetProgress(timeToLive/10f);
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
    public void AddTimeToLive(int time = 4+4/2) 
    {
        timeToLive += time;
        if (timeToLive > 10)
        {
            timeToLive = 10;
        }
    }
}
