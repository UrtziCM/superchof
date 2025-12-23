using DG.Tweening;
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
    private float minScale = 0.3f;
    [SerializeField] 
    private Transform characterModel;

    public bool isDying = false;

    void Update()
    {
        if(deathMenuCanvas.activeSelf || mainMenuCanvas.activeSelf) return;
        if(isDying) return;

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
        if(isDying) return;
        isDying = true;

        characterModel.DOScale(Vector3.zero, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            GameManager.Instance.GameEnd();
        });
    }

    public void DieGrill()
    {
        if(isDying) return;
        isDying = true;

        characterModel.DOScaleY(0f, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            GameManager.Instance.GameEnd();
        });
    }

    public void DieSunlight()
    {
        if (isDying) return;
        isDying = true;

        characterModel.DOScaleY(0f, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            GameManager.Instance.GameEnd();
        });
    }

    public void DieCoffee()
    {
        if (isDying) return;
        isDying = true;

        characterModel.DOLocalMoveY(-1.5f, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            GameManager.Instance.GameEnd();
        });
    }

    public void DieSteam()
    {
        if (isDying) return;
        isDying = true;

        float startPos = characterModel.localPosition.x;
        float startScale = characterModel.localScale.x;

        Sequence steamDeathSequence = DOTween.Sequence();

        steamDeathSequence.Append(characterModel.DOScaleX(0f, 0.5f).SetEase(Ease.Linear));
        steamDeathSequence.Join(characterModel.DOLocalMoveX(startPos + (startScale * 0.5f), 0.5f).SetEase(Ease.Linear));

        steamDeathSequence.OnComplete(() =>
        {
            GameManager.Instance.GameEnd();
        });
    }
    public void AddTimeToLive(int time = 4+4/2) 
    {
        if(isDying) return;

        timeToLive += time;
        if (timeToLive > 10)
        {
            timeToLive = 10;
        }
    }
}
