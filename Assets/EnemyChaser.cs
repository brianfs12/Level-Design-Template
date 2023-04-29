using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public bool playerseen;
    [SerializeField]Vector3 playerPosition;
    public float speed;
    public float step;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerseen)
        {
            Move();
        }
    }

    void Move()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(playerPosition.x,transform.position.y, playerPosition.z)  , step);
        transform.LookAt(playerPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerseen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerseen = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPosition = other.transform.position;
        }
    }
}
