using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootShotgun : MonoBehaviour
{
    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            /*
            Instantiate(bullet, gun[0].transform.position, gun[0].transform.rotation);
            Instantiate(bullet, gun[1].transform.position, gun[1].transform.rotation);
            Instantiate(bullet, gun[2].transform.position, gun[2].transform.rotation);
            Instantiate(bullet, gun[3].transform.position, gun[3].transform.rotation);
            Instantiate(bullet, gun[4].transform.position, gun[4].transform.rotation);
            Instantiate(bullet, gun[5].transform.position, gun[5].transform.rotation);
            */
    /*
            int i = 0; // more efficient
            while (i < gun.Count)
            {
                Instantiate(bullet, gun[i].transform.position, gun[i].transform.rotation);
                i++;
            }
        }
    }
    */

    public GameObject bullet;
    public List<GameObject> gun;
    public float shootDelay ;

    private playerInventory pInventory;
    private bool shootNow;

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
            pInventory.activeWeapon = "Shotgun";

            // Shoots if have ammo.
            if (pInventory.shotgunAmmo > 0)
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
        int i = 0; // more efficient
        while (i < gun.Count)
        {
            Instantiate(bullet, gun[i].transform.position, gun[i].transform.rotation);
            i++;
        }
        pInventory.shotgunAmmo--;

        yield return new WaitForSeconds(shootDelay);
        shootNow = true;
    }
}
