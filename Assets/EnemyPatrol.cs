using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public List<Transform> points;
    public int index;
    public float speed;
    public float step;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, points[index].position) < 0.001f)
        {
            index++;
            if (index == points.Count)
            {
                index = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, points[index].position, step);
    }
}
