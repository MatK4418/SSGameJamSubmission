using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHP : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    public GameObject UIGameOverScreen;

    private Vector3 gibSpawn;
    private Rigidbody rb;
    

    [HideInInspector]
    public bool playerIsAlive;

    void Start()
    {
        playerIsAlive = true;
        currentHP = maxHP;
    }

    void Update()
    {
        if (currentHP <= 0f)
        {
            //Disables Movement
            gameObject.GetComponent<RBMovement>().enabled = false;

            //Releases rigidbody constraints, making the player fall over.
            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;

            // Shows game over screen.
            StartCoroutine(deathTimer());
        }

        if (playerIsAlive == false)
        {
            if (Input.GetKeyDown("r")) // Reloads Level
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    private IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(3f);

        playerIsAlive = false;

        if (UIGameOverScreen != null)
        {
            UIGameOverScreen.SetActive(true);
        }
    }

    // Damage function, can be called by other scripts (E.G. Rocket Splash Damage)
    public void pTakeDamage(float damage)
    {
        currentHP -= damage;
    }
}
