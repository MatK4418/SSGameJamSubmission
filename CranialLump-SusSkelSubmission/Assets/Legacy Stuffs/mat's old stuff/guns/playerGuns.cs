using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGuns : MonoBehaviour
{
    public int selectedWeapon = -1;

    //[DEPRECATED] public GameObject[] eqWeapons; // WRONG way of setting up lists. These don't support the "Contains" and "Add" Functions.
    //[DEPRECATED] public GameObject[] allWeapons; // Still don't entirely understand what these actually are, seeing as they behave similarly.

    public List<GameObject> eqWeapons; // "Equipped" Weapons
    public List<GameObject> allWeapons; // All weapons in the game, assigned in the editor
    private playerInventory pInventory;

    void Start()
    {

    }

    void Update()
    {
        // Switches player's weapons when mousewheel is used.
        // source: https://www.youtube.com/watch?v=Dn_BUIVdAPg
        if (eqWeapons.Count > 1f)
        {
            float MScroll = Input.GetAxis("Mouse ScrollWheel");
            int listIndex = eqWeapons.Count - 1;

            if (MScroll > 0f) // Mousewheel Forwards
            {
                eqWeapons[selectedWeapon].SetActive(false);
                if (selectedWeapon != listIndex)
                {
                    eqWeapons[++selectedWeapon].SetActive(true);
                }
                else
                {
                    selectedWeapon = 0;
                    eqWeapons[selectedWeapon].SetActive(true);
                }
            }
            else if (MScroll < 0f) // Mousewheel Backwards
            {
                eqWeapons[selectedWeapon].SetActive(false);
                if (selectedWeapon != 0)
                {
                    eqWeapons[--selectedWeapon].SetActive(true);
                }
                else
                {
                    selectedWeapon = listIndex;
                    eqWeapons[selectedWeapon].SetActive(true);
                }
            }  
        }
        else if (eqWeapons.Count == 1f)
        {
            selectedWeapon = 0;
            eqWeapons[selectedWeapon].SetActive(true);
        }
    }

    // Checks if you picked up one of the weapons, then loads the inventory and checks which one.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pistol Pickup"))
            addWeapon(allWeapons[0]);
        if (other.CompareTag("Shotgun Pickup"))
            addWeapon(allWeapons[1]);
        if (other.CompareTag("Launcher Pickup"))
            addWeapon(allWeapons[2]);
    }

    void addWeapon(GameObject newWeapon) //Function that checks if you have the gun already.
    {
        if(!eqWeapons.Contains(newWeapon))
            eqWeapons.Add(newWeapon);
    }

    //https://answers.unity.com/questions/906057/adding-gameobjects-to-a-list.html

}
