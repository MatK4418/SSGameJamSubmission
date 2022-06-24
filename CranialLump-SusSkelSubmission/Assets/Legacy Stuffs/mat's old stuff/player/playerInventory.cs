using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    public bool haveRedKey, haveBlueKey, haveYellowKey = false;
    public int pistolAmmo, shotgunAmmo, rocketAmmo = 0;
    private playerHP pHP;
    public string activeWeapon;

    void Start()
    {
        pHP = GetComponent<playerHP>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Effient switch statement is efficient.
        switch (other.transform.tag)
        {
            // Key Pickups
            case "Red Key":
                haveRedKey = true;
                break;
            case "Blue Key":
                haveBlueKey = true;
                break;
            case "Yellow Key":
                haveYellowKey = true;
                break;

            // Gun Pickups
            case "Pistol Pickup":
                pistolAmmo += 12;
                break;
            case "Shotgun Pickup":
                shotgunAmmo += 6;
                break;
            case "Launcher Pickup":
                rocketAmmo += 2;
                break;

            // Ammo Pickups
            case "Pistol Ammo":
                pistolAmmo += 12;
                break;
            case "Shotgun Ammo":
                shotgunAmmo += 8;
                break;
            case "Launcher Ammo":
                rocketAmmo += 4;
                break;

            // Health Pickups
            case "Healing Item":
                HealPlayer(10f);
                break;
        }
    }

    // Dev cheat, pls ignore >.<
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Ammo Cheat! Fuck You!");
            pistolAmmo += 100;
            shotgunAmmo += 100;
            rocketAmmo += 100;
        }
    }

    // Heal function.
    // If the heal would result in more than the max, it sets it to the max.
    // If the heal would result in less than the max, it adds the amount healed.
    // If the heal would result in equity with the max, nothing changes.
    void HealPlayer(float heal)
    {
        if ((heal + pHP.currentHP) > pHP.maxHP)
            pHP.currentHP = pHP.maxHP;
        else if ((heal + pHP.currentHP) <= pHP.maxHP)
            pHP.currentHP += heal;
    }
}
