using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public GameObject enemyProjectile;

    private GameObject pObject;
    public bool meleeMode = false;
    public bool attackNow = true;

    private void OnEnable()
    {
        // Melee Attack
        if (TryGetComponent(out Collider meleeCollider))
        {
            meleeMode = true;
        }

        // Ranged Attack
        else
        {
            pObject = GameObject.Find("PlayerObject");
            attackNow = true;
        }
    }

    private void Update()
    {
        /*
        // Ranged Attack Continued (MOVED THIS PART TO CHASE SCRIPT)
        if (!meleeMode && attackNow)
        {
            attackNow = false;
            StartCoroutine(Cooldown(2f));
        } */
    }

    private void OnTriggerStay(Collider other)
    {
        // Melee Attack Continued
        if (meleeMode)
        {
            if (other.gameObject.tag == "Player")
            {
                if (attackNow == true)
                    StartCoroutine(MeleeAttack(4f, other));
            }
        }
    }

    // Function for shooting
    public IEnumerator ShootProjectile(float cd)
    {
        attackNow = false;

        // Points Invisible Gun at player
        gameObject.transform.LookAt(pObject.transform);

        // Shows player that enemy is about to shoot.
        yield return new WaitForSeconds(cd);

        // Shoots projectile
        if (enemyProjectile != null)
            Instantiate(enemyProjectile, gameObject.transform.position, gameObject.transform.rotation);
        else
            Debug.LogError("No enemy projectile or collider detected!");

        // Reset Attack State (COOLDOWN USED TO BE HERE, SWITCHED TO WARN PLAYER)
        attackNow = true;
    }

    public IEnumerator MeleeAttack(float cd, Collider other)
    {
        // Shows player that enemy is about to shoot.
        attackNow = false;
        yield return new WaitForSeconds(cd);

        // Attacks player
        playerHP pHP = other.gameObject.GetComponent<playerHP>();
        pHP.pTakeDamage(40f);
        attackNow = true;


    }
}
