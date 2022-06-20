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

    void Start()
    {
        bCollider = GetComponent<Collider>();
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * speed * 100f);
    }
    
    void FixedUpdate()
    {
        deathTimer -= Time.deltaTime;
        if (deathTimer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.GetContact(0);

        
        if (other.gameObject.tag == "Gun")
        {
            Physics.IgnoreCollision(other.transform.GetComponent<Collider>(), bCollider);
        }
        
        else if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Light Enemy" || other.gameObject.tag == "Heavy Enemy")
        {
            Instantiate(enemyParticles, contact.point, Quaternion.LookRotation(contact.normal, Vector3.up)); // Spawns blood splatter.
        }

        else if (other.gameObject.tag == "Environment")
        {
            Instantiate(enviroParticles, contact.point, Quaternion.LookRotation(contact.normal, Vector3.up));
            Destroy(gameObject);

            //Credit for learning about contact points: https://www.youtube.com/watch?v=2bPd_dmqGuM
        }
    }
}
