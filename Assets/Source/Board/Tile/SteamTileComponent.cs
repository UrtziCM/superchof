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

    private bool activeSteam = false;

    [SerializeField]
    private TileComponent[] tiles;

    [SerializeField]
    private GameObject[] pipes;

    [SerializeField]
    private ParticleSystem steamParticle;

    [SerializeField]
    public float timeToChange = 2;

    [SerializeField] private AudioClip steam;
    IEnumerator Start()
    {

        steamTimer = timeBetweenSteam;
        activeSteam = false;

        while (true)
        {
            yield return new WaitForSeconds(2);
            yield return StartCoroutine(BaseToHotIndexChanger(0,1,timeToChange));
            yield return StartCoroutine(PipeSteam());
            yield return StartCoroutine(BaseToHotIndexChanger(1,0,1));
        }
    }

    private IEnumerator BaseToHotIndexChanger(int start, int end, float time)
    {
        float toRed = 0;
        float intensity = 0;

        while (toRed < time)
        {
            toRed += Time.deltaTime;

            intensity = math.lerp(start, end, toRed / time);
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
        AudioManager.instance.PlaySound(steam, transform, 0.5f);
        ToperToSteam();
        yield return new WaitForSeconds(steamActiveTime);
        steamParticle.Stop();
        ToperToNone();
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
