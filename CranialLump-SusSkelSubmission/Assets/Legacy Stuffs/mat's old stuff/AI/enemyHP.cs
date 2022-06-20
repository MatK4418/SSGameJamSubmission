using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour
{
    public float totalHP;
    public float currentHP;

    public GameObject gibs;
    private Vector3 gibSpawn;

    void Start()
    {
        currentHP = totalHP;
    }

    // Spawns blood splatters depending on where the enemy was struck. More realistic/satisfying.
    void Update()
    {
        if (currentHP <= 0f)
        {
            gibSpawn = new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y + 1), gameObject.transform.position.z);
            Instantiate(gibs, gibSpawn, Quaternion.LookRotation(Vector3.up, Vector3.up));
            Destroy(gameObject);
        }
    }

    // Enemy Direct Impact Damage
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
            TakeDamage(10f);
        if (collision.gameObject.CompareTag("Heavy Bullet"))
            TakeDamage(25f);
        if (collision.gameObject.CompareTag("Rocket"))
            TakeDamage(40f);
    }

    // Damage function, can be called by other scripts (E.G. Rocket Splash Damage)
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        Debug.Log("Enemy HP: " + currentHP);
    }
}
