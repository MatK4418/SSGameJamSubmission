using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIAmmo : MonoBehaviour
{
    private Text ammoDisplay;
    private GameObject pObject;
    private playerInventory pInventory;

    private void Start()
    {
        ammoDisplay = GetComponent<Text>();
        pObject = GameObject.Find("PlayerObject");
        pInventory = pObject.GetComponent<playerInventory>();
    }
    private void Update()
    {
        if (ammoDisplay != null)
        {
            /*
            if (pInventory.activeWeapon == "Pistol")
                ammoDisplay.text = pInventory.pistolAmmo.ToString();
            else if (pInventory.activeWeapon == "Shotgun")
                ammoDisplay.text = pInventory.shotgunAmmo.ToString();
            else if (pInventory.activeWeapon == "Rocket Launcher")
                ammoDisplay.text = pInventory.rocketAmmo.ToString();
            else
                ammoDisplay.text = "0";
            */

            switch (pInventory.activeWeapon) // More Efficient, not much else.
            {
                case "Pistol":
                    ammoDisplay.text = pInventory.pistolAmmo.ToString();
                    break;
                case "Shotgun":
                    ammoDisplay.text = pInventory.shotgunAmmo.ToString();
                    break;
                case "Rocket Launcher":
                    ammoDisplay.text = pInventory.rocketAmmo.ToString();
                    break;
                default:
                    ammoDisplay.text = "0";
                    break;
            }
        }
    }
}
