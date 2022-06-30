using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMONO : MonoBehaviour
{
    public Slider slider;
    public GameObject deathGibs;

    [SerializeField]
    protected HealthOS health;

    protected playerKillScore playerKillScore;
    private Vector3 gibSpawn;


    public void Start()
    {
        health.ValueHealth = health.maxHealth;

        slider.maxValue = health.maxHealth;
    }

    public void Update()
    {
        slider.value = health.ValueHealth;

        if (health.ValueHealth <= 0)
        {
            if (gameObject.activeInHierarchy)
            {
                playerKillScore.Score += 1;
            }

            // Mat Code .O.
            if (deathGibs != null)
            {
                gibSpawn = new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y + 0.1f), gameObject.transform.position.z);
                Instantiate(deathGibs, gibSpawn, Quaternion.LookRotation(Vector3.up, Vector3.up));
            }
            // Mat Code end. :pensive:

            Destroy(gameObject);
        }
            
           
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AutoBullet"))
            TakeDamage(health.AutoDamage);
        else if (collision.gameObject.CompareTag("SpreadBullet"))
            TakeDamage(health.SpreadDamage);
        else if (collision.gameObject.CompareTag("SingleBullet"))
            TakeDamage(health.SingleDamage);
    }

    public void TakeDamage(int damage)
    {
        health.ValueHealth -= damage;

    }
}
