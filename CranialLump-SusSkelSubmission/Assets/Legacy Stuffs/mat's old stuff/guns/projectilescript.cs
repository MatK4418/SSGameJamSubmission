using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilescript : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Collider bCollider;
    public float deathTimer;
    public GameObject enemyParticles;
    public GameObject enviroParticles;

    [SerializeField]
    protected Health health;

    void Start()
    {
        bCollider = GetComponent<Collider>();
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed * 100f);
    }
    
    void FixedUpdate()
    {
        deathTimer -= Time.deltaTime; //ras commenting to help his smooth brain me like this 
        if (deathTimer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.GetContact(0);
        
        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(enemyParticles, contact.point, Quaternion.LookRotation(contact.normal, Vector3.up)); // Spawns blood splatter. 
            Destroy(gameObject);
        }

        else if (other.gameObject.tag == "Environment")
        {
            Instantiate(enviroParticles, contact.point, Quaternion.LookRotation(contact.normal, Vector3.up)); 
            Destroy(gameObject);
            //Credit for learning about contact points: https://www.youtube.com/watch?v=2bPd_dmqGuM
        }
    }
}
