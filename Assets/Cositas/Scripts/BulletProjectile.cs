using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    float speed = 10;

    // Start is called before the first frame update
    void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("EnemyVision"))
        {
        }
        else if(other.CompareTag("Enemy"))
        {
            if(other.GetComponent<EnemyHealth>())
            other.GetComponent<EnemyHealth>().RecibirDaño();
            else
            {
                other.transform.root.GetComponent<EnemyHealth>().RecibirDaño();
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
