using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    public static int health;


    private void Awake()
    {
        health = 10;
    }
    private void FixedUpdate()
    {
        if(health <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        Destroy(gameObject);
        Debug.Log("YIP YEEE");
    }
}
