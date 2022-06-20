using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorLocked : MonoBehaviour
{
    public bool openDoor = false;
    public bool locked = true;
    public string requiredKey;
    private Animator animator;
    private playerInventory pInventory;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("playerIsNearby", openDoor);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (locked)
            {
                pInventory = other.GetComponent<playerInventory>();
                if (requiredKey == "Red Key")
                {
                    if (pInventory.haveRedKey)
                        Unlock();
                }
                else if (requiredKey == "Blue Key")
                {
                    if (pInventory.haveBlueKey)
                        Unlock();
                }
                else if (requiredKey == "Yellow Key")
                {
                    if (pInventory.haveYellowKey)
                        Unlock();
                }
            }
            else
                openDoor = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            openDoor = false;
    }

    void Unlock()
    {
        locked = false;
        openDoor = true;
    }
}
