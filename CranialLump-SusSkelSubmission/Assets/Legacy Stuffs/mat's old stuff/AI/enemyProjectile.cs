using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Collider bCollider;
    public float deathTimer;
    public GameObject explosionParticles;

    void Start()
    {
        bCollider = GetComponent<Collider>();
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed * 100f);
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
        // Ignores collision if it hits itself or a player projectile
        
        if (other.gameObject.tag == "Light Enemy")
        {
            Physics.IgnoreCollision(other.transform.GetComponent<Collider>(), bCollider);
        }
        

        // Deals damage and Instantiates particles wherether the projectile hits
        else 
        {
            ContactPoint contact = other.GetContact(0);

            if (other.gameObject.tag == "Player")
            {
                playerHP pHP = other.gameObject.GetComponent<playerHP>();
                pHP.pTakeDamage(20f);

                Instantiate(explosionParticles, contact.point, Quaternion.LookRotation(Vector3.up, Vector3.up));
                Destroy(gameObject);
            }

            else if (other.gameObject.tag == "Environment" || other.gameObject.tag == "Heavy Enemy")
            {
                Instantiate(explosionParticles, contact.point, Quaternion.LookRotation(Vector3.up, Vector3.up));
                Destroy(gameObject);

                //Credit for learning about contact points: https://www.youtube.com/watch?v=2bPd_dmqGuM
            }
        }
    }
}
