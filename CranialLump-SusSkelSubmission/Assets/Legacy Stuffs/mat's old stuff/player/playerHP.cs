using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    public float maxHP;
    public float currentHP;

    private Vector3 gibSpawn;

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        if (currentHP <= 0f)
        {
            // Screen Shake
        }
    }

    // Damage function, can be called by other scripts (E.G. Rocket Splash Damage)
    public void pTakeDamage(float damage)
    {
        currentHP -= damage;
        Debug.Log("Player HP: " + currentHP);
    }
}
