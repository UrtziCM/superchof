using UnityEngine;

public class LavaTileComponent : TileComponent
{
    private Collider MovementCheckBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetTileTop(TILE_TOP.COFFEE);
        attachPosition = transform.position;
        MovementCheckBox = GetComponent<Collider>();
    }

    // TODO: Make this solution better I don't like this each frame
    void Update()
    {
        MovementCheckBox.enabled = true;
        SetTileTop(TILE_TOP.COFFEE);

        foreach (Collider col in Physics.OverlapBox(attachPosition, Vector3.one * .25f))
        {
            if (col.GetComponent<MovingTileComponent>() != null)
            {
                MovementCheckBox.enabled = false;
                SetTileTop(TILE_TOP.NONE);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(attachPosition + transform.position, Vector3.one * .25f);
        Gizmos.DrawWireCube(transform.position, Vector3.one * .99f);

    }
}
