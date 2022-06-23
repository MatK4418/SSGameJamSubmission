using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create weapon", order = 1)]
public class Weapons : ScriptableObject
{
    public string weaponName;
    public float fireRate;
    
    public ShotType shotType;

    public int ShotCount;
    public float spreadAngle;


    [SerializeField]
    public GameObject SingleBullet;
    public GameObject AutoBullet;
    public GameObject SpreadBullet;
    public enum ShotType
    {
        Auto , Single, Spread 
    }
    
}
