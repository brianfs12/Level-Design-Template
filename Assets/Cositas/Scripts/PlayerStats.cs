using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int vidaActual;
    public int vidaMaxima;
    [SerializeField] Transform ReturnZone;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaActual == 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        vidaActual = vidaMaxima;
        transform.position = ReturnZone.position;
    }
    public void RecibirDaño()
    {
        vidaActual--;
    }
}
