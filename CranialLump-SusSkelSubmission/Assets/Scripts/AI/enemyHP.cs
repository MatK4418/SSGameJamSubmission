using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour
{
    public float totalHP;
    public float currentHP;

    public GameObject gibs;
    private Vector3 gibSpawn;

    public float AutoDamage = 10f; // Default values, made them modular so that you can make "armored" enemies by reducing damage through editor.
    public float SpreadDamage = 25f;
    public float SingleDamage = 40f;

    void Start()
    {
        currentHP = totalHP;
    }

    // Spawns blood splatters depending on where the enemy was struck. More realistic/satisfying.
    void Update()
    {
        if (currentHP <= 0f)
        {
            if (gibs != null)
            {
                gibSpawn = new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y + 1), gameObject.transform.position.z);
                Instantiate(gibs, gibSpawn, Quaternion.LookRotation(Vector3.up, Vector3.up));
            }
            Destroy(gameObject);
        }
    }

    // Enemy Direct Impact Damage
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AutoBullet"))
            TakeDamage(AutoDamage);
        if (collision.gameObject.CompareTag("SpreadBullet"))
            TakeDamage(SpreadDamage);
        if (collision.gameObject.CompareTag("SingleBullet"))
            TakeDamage(SingleDamage);
    }

    // Damage function, can be called by other scripts (E.G. Rocket Splash Damage)
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
    }
}
