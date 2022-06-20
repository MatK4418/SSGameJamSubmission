using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private Rigidbody rb;
    private float deathCounter;
    private bool hasExploded = false;
    private Collider bCollider;

    public float speed;
    public float delay = 3f;
    public float blastRadius = 5f;
    public float blastForce = 500f;

    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        bCollider = GetComponent<Collider>();
        deathCounter = delay;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * speed * 100f);
    }

    // Update is called once per frame
    void Update()
    {
        deathCounter -= Time.deltaTime;
        if (!hasExploded && deathCounter <= 0f)
        {
            Explode();
            hasExploded = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Gun")
        {
            Physics.IgnoreCollision(other.collider, bCollider);
        }
        else if (other.gameObject.tag == "Light Enemy" || other.gameObject.tag == "Heavy Enemy" || other.gameObject.tag == "Environment")
        {
            if (!hasExploded)
            {
                Explode();
                hasExploded = true;
            }
        }
    }

    void Explode()
    {
        // Show effect
        if (explosionEffect != null)
            Instantiate(explosionEffect, transform.position, transform.rotation);

        // Get nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        // Explosion Effect
        foreach (Collider nearbyObject in colliders)
        {
            // Knock Rigidbodies away, including player
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(blastForce, transform.position, blastRadius);
            }

            // Apply Splash Damage
            if (nearbyObject.gameObject.tag == "Light Enemy" || nearbyObject.gameObject.tag == "Heavy Enemy")
            {
                enemyHP eHP = nearbyObject.GetComponent<enemyHP>();
                if (eHP != null)
                {
                    eHP.TakeDamage(10f);
                }
            }
            if (nearbyObject.gameObject.tag == "Player")
            {
                playerHP pHP = nearbyObject.GetComponent<playerHP>();
                if (pHP != null)
                {
                    pHP.pTakeDamage(10f);
                }
            }
        }

        // Remove Granade
        Destroy(gameObject);

        // Brackeys. (2017) GRENADE / BOMB in Unity (Tutorial) [online]. Available from: https://www.youtube.com/watch?v=BYL6JtUdEY0 [Accessed: 21st April 2022]
    }
}
