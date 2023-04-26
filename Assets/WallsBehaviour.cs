using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsBehaviour : MonoBehaviour
{
    [SerializeField] List<bool> activeWalls;
    [SerializeField] List<Transform> allChildren;
    public int childrenCount = 0;

    void Start()
    {

    }

    private void WallsManager(GameObject wall, bool enable)
    {
        wall.SetActive(enable);
    }

    private void OnValidate()
    {
        if (allChildren.Count == 0)
        {
            foreach (Transform child in transform)
            {
                allChildren.Add(child);
                if (child.transform.childCount > 0)
                {
                    foreach (Transform babyChild in child.transform)
                    {
                        allChildren.Add(babyChild);
                        childrenCount++;
                    }
                }
                childrenCount++;
            }

        }
        if (childrenCount != allChildren.Count)
        {
            childrenCount = allChildren.Count;
        }
        if (childrenCount != activeWalls.Count)
        {
            foreach (Transform child in allChildren)
            {
                if (childrenCount > activeWalls.Count)
                {
                    activeWalls.Add(child.gameObject.activeInHierarchy);
                }

            }
        }
        for(int i = 0; i < activeWalls.Count; i++)
        {
            if(allChildren[i].gameObject.activeInHierarchy != activeWalls[i])
            {
                allChildren[i].gameObject.SetActive(activeWalls[i]);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
