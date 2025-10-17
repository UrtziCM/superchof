using UnityEngine;

public enum casilla { TOOPPER, TRAP, BASE, ICECUBE }

public class Casilla : MonoBehaviour
{
    public Transform casillaPosition;

    public Vector3 GetPossition() 
    {
        return casillaPosition.position;
    }
}
