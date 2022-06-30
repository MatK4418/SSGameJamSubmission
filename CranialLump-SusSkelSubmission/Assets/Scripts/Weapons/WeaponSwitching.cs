using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField]
    GameObject Auto, Spread, Single;

    playerKillScore playerKillScore;
  

   /* public enum Weapon
    {
        automatic, Shotgun, Pistol
    }*/

   
    private void Update()
    {
        /*  switch (Weapon)
          {
              case Weapon.automatic:
                  autoBool = true;
                  spreadBool = false;
                  singleBool = false;
                  break;

              case Weapon.Shotgun:
                  autoBool = false;
                  spreadBool = true;
                  singleBool = false;
                  break;

              case Weapon.Pistol:
                  autoBool = false;
                  spreadBool = false;
                  singleBool = true;
                  break;
          }*/

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Auto.SetActive(false);
            Spread.SetActive(false);
            Single.SetActive(true);
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            Auto.SetActive(false);
            Spread.SetActive(true);
            Single.SetActive(false);
           
          
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            Auto.SetActive(true);
            Spread.SetActive(false);
            Single.SetActive(false);
           
        }


       
     }
 }

