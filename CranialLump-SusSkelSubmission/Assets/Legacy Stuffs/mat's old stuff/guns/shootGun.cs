using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootGun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gun;

    private playerInventory pInventory;
    private bool shootNow;
    public float shootDelay;

    void OnEnable()
    {
        pInventory = GetComponentInParent<playerInventory>();
        shootNow = true;
    }
    void Update()
    {
        if (pInventory != null)
        {
            // Changes active weapon variable, affects UI.
            pInventory.activeWeapon = "Pistol";

            // Shoots if have ammo.
            if (pInventory.pistolAmmo > 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (shootNow)
                        StartCoroutine(Shoot());
                }
            }
            else
            {
                // TODO: Click sound
                // TODO: Gun Shake animation
            }
        }
    }

    private IEnumerator Shoot()
    {
        shootNow = false;

        //NOTE: THIS WAS MOVED FROM UPDATE TO HERE IN ORDER TO IMPLEMENT DELAY. SAME APPLIES TO OTHER GUNS.
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        pInventory.pistolAmmo--;

        yield return new WaitForSeconds(shootDelay);
        shootNow = true;
    }
}
