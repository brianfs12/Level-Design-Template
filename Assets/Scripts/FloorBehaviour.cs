using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehaviour : MonoBehaviour
{
    enum TYPE_OF_TILE
    {
        NORMAL,
        SOLID,
        SPIKES,
        TIME_SPIKES,
        PERMANENT_SPIKES,
        EXIT_SPIKES,
        PROXIMITY_SPIKES,
        FALLING_FLOOR,
        EXIT,
        PROTECTION
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
}
