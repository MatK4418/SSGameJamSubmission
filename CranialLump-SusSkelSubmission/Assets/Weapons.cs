using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon script Object", order = 1)]
public class Weapons : ScriptableObject
{
    public string weaponName;
    public float fireRate;


    [SerializeField]
    public GameObject Bullet;
}
