using System.Collections;
using UnityEngine;

public class SteamTileManager : MonoBehaviour
{
    [SerializeField]
    public float timeBetweenSteam = 5f;

    [SerializeField]
    private float steamActiveTime = 3f;

    private float steamTimer;

    private bool activeSteam;

    [SerializeField]
    private TileComponent[] tiles;

    [SerializeField]
    private GameObject[] pipes;

    [SerializeField]
    private GameObject steamSpot;
    void Start()
    {
        steamTimer = timeBetweenSteam;
        activeSteam = false;
    }


    void Update()
    {
        if (!activeSteam && steamTimer > 0)
        {
            steamTimer -= Time.deltaTime;
        }
        else if (!activeSteam)
        {
            StartCoroutine(PipeSteam());
        }
    }

    private IEnumerator PipeSteam()
    {
        ToperToSteam();
        yield return new WaitForSeconds(steamActiveTime);
        ToperToNone();
        steamTimer = timeBetweenSteam;
    }

    private void ToperToSteam()
    {
        activeSteam = true;
        foreach (var tileComponent in tiles)
        {
            tileComponent.SetTileTop(TILE_TOP.STEAM);
        }
    }

    private void ToperToNone()
    {
        activeSteam = false;
        foreach (var tileComponent in tiles)
        {
            tileComponent.SetTileTop(TILE_TOP.NONE);
        }
    }


}
