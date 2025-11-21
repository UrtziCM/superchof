using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
    private ParticleSystem steamParticle;

    [SerializeField]
    public float timeToChange = 2;
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
            if (steamTimer <= 2)
            {
                StartCoroutine(BaseToHot());
                

            }
            if (steamTimer < 0)
            {
                StartCoroutine(PipeSteam());
            }
        }
    }

    private IEnumerator BaseToHot()
    {
        float toRed = 0;

        float intensity = 0;

        while (toRed < timeToChange)
        {
            toRed += Time.deltaTime;

            intensity = math.lerp(0, 1, toRed / timeToChange);
            Debug.Log(intensity);
            foreach (GameObject r in pipes)
            {
                Material BaseToRed = r.GetComponentInChildren<Renderer>().material;
                BaseToRed.SetFloat("_Index", intensity);
            }

            yield return null;
        }
    }
    private IEnumerator PipeSteam()
    {
        steamParticle.Play();
        ToperToSteam();
        yield return new WaitForSeconds(steamActiveTime);
        steamParticle.Stop();
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
