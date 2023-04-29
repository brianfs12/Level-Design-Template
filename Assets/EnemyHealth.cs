using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int vidaActual;
    public int vidaMaxima;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecibirDaño()
    {
        vidaActual--;
        if(vidaActual <= 0)
        {
            if (transform.parent)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            Destroy(gameObject);
        }
    }
}
