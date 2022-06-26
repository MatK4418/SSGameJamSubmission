using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMONO : MonoBehaviour
{
    public Slider slider;

    [SerializeField]
    protected HealthOS health;


    public void Start()
    {
        health.ValueHealth = health.maxHealth;

        slider.maxValue = health.maxHealth;
    }

    public void Update()
    {
        slider.value = health.ValueHealth;

        if (health.ValueHealth <= 0)
            Destroy(gameObject);
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
