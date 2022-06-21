using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsMONO : MonoBehaviour
{
    [SerializeField]
    Transform muzzle;

    float fireTime = 0f;

    [SerializeField]
    protected Weapons weapons;

    public void Start()
    {
        
    }


    bool CheckFireRate()
    {
        if (Time.time >= fireTime)
        {
            fireTime = Time.time + (1f / weapons.fireRate);
            return true;
        }
        
        return false;
    }
    public void Update()
    {
        shootingInput();
        
    }

    void shootingInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (CheckFireRate())
                createBullet(muzzle);

        }
       /* else if (weapons.shotType == Weapons.ShotType.Single)
        {
            createBullet(muzzle);
            
        }*/

    }



    public GameObject createBullet(Transform origin)
    {
        GameObject projectile = Instantiate(weapons.Bullet, origin.position, origin.rotation, null);

        return projectile;
    }

    //public abstract void Shoot();
    
}
