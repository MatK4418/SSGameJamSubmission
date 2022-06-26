using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyHealth", order =1)]
public class HealthOS : ScriptableObject
{
    public string HealthName;
    public int ValueHealth;
    public int maxHealth;
    public int AutoDamage;
    public int SpreadDamage;
    public int SingleDamage;

    
   
}
