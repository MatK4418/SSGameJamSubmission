using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon script Object", order = 1)]
public class Weapons : ScriptableObject
{
    public string weaponName;
    public float fireRate;

    public ShotType shotType;

    [SerializeField]
    public GameObject Bullet;

    void Init()
    {

    }
    

    public enum ShotType
    {
        Auto, Single, Spread
    }
}
