using UnityEditorInternal;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    [SerializeField] 
    public float timeToLive = 10f;

    void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
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

    }
}
