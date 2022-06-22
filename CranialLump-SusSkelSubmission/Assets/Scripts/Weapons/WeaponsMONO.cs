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

            if (weapons.shotType == Weapons.ShotType.Single && CheckFireRate())
                createSingleShotBullet(muzzle);
            //else if (weapons.shotType == Weapons.ShotType) 
            else if (weapons.shotType == Weapons.ShotType.Auto && CheckFireRate())
                createAutoShotBullet(muzzle);

            else if (weapons.shotType == Weapons.ShotType.Spread && CheckFireRate())
                createSpreadShotBullet(muzzle);
                
        }
      

    }

    
   public GameObject createSpreadShotBullet(Transform origin)
    {
        GameObject projectile = Instantiate(weapons.SpreadBullet, origin.position, origin.rotation, null);

        return projectile;
    }
    public GameObject createAutoShotBullet(Transform origin)
    {
        GameObject projectile = Instantiate(weapons.AutoBullet, origin.position, origin.rotation, null);

        return projectile;
    }

    public GameObject createSingleShotBullet(Transform origin)
    {
        GameObject projectile = Instantiate(weapons.SingleBullet, origin.position, origin.rotation, null);

        return projectile;
    }

    //public abstract void Shoot();
    
}
