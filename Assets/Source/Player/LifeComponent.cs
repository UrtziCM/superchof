using System;
using UnityEditorInternal;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    [SerializeField]
    private HPCanvasHelper _hpCanvasHelper;

    public float timeToLive = 10f;
    [HideInInspector]
    public bool debugIsInvincible = false;
    
    [SerializeField]
    private GameObject deathMenuCanvas;
    [SerializeField]
    private GameObject mainMenuCanvas;

    [SerializeField]
    private float minScale = 0.2f;
    [SerializeField] 
    private Transform characterModel;

    void Update()
    {
        if(deathMenuCanvas.activeSelf || mainMenuCanvas.activeSelf) return;

        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0 && !debugIsInvincible)
        {
            DieMolten();
        }
        _hpCanvasHelper.SetProgress(timeToLive/10f);

        scaleCharacter(timeToLive/10f);
    }

    private void scaleCharacter(float life)
    { 
        float scale = Mathf.Lerp(minScale, 1f, life);
        characterModel.localScale = new Vector3(scale, scale, scale);
    }

    public void DieMolten() 
    {
        //Animacion
        GameManager.Instance.GameEnd();
    }

    public void DieGrill()
    {
        //Animacion
        Debug.Log("DIE GRILL");
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
