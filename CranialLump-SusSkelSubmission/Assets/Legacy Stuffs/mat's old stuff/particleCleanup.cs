using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleCleanup : MonoBehaviour
{
    public float deathTimer = 2f;
    void FixedUpdate()
    {
        deathTimer -= Time.deltaTime;
        if (deathTimer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
