using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehaviour : MonoBehaviour
{
    enum TYPE_OF_TILE
    {
        NORMAL,
        SPIKES,
        FALLING_FLOOR,
        GOAL
    };

    [SerializeField] TYPE_OF_TILE typeOfTile;
    public MeshRenderer mesh;
    public Material []floorMaterials;
    int materialIndex;

    // Start is called before the first frame update
    void Start()
    {
        materialIndex = 0;
        this.GetComponent<MeshRenderer>();
    }

    private void OnValidate()
    {
        materialIndex = (int)typeOfTile;
        mesh.material = floorMaterials[materialIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (typeOfTile)
            {
                case TYPE_OF_TILE.SPIKES:
                    collision.gameObject.GetComponent<PlayerStats>().RecibirDaño(); ;
                    break;
            }
        }
    }
}
