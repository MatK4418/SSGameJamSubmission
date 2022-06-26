using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemyHP : MonoBehaviour
{
    public float maxHP;
    public float currentHP;

    public GameObject gibs;
    private Vector3 gibSpawn;

    public float AutoDamage = 10f;
    public float SpreadDamage = 5f;
    public float SingleDamage = 40f;

    [SerializeField]
    Slider slider;
    private GameObject player;



    private void Awake()
    {
        
        currentHP = maxHP;
        if(currentHP > 0)
        {
            //slider = GameObject.Find("Slider").GetComponent<Slider>();
            player = GameObject.Find("PlayerObject");
            slider.maxValue = maxHP;
        }
    }

    // Spawns blood splatters depending on where the enemy was struck. More realistic/satisfying.

    private void Start()
    {
        
    }
    void Update()
    {
        slider.value = currentHP;
        if (currentHP <= 0f)
        {
            if (gibs != null)
            {
                gibSpawn = new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y + 1), gameObject.transform.position.z);
                Instantiate(gibs, gibSpawn, Quaternion.LookRotation(Vector3.up, Vector3.up));
            }
            Destroy(gameObject);
        }
        else
        {
            slider.transform.rotation = player.gameObject.transform.rotation;

        }
    }

    // Enemy Direct Impact Damage
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AutoBullet"))
            TakeDamage(AutoDamage);
        else if (collision.gameObject.CompareTag("SpreadBullet"))
            TakeDamage(SpreadDamage);
        else if (collision.gameObject.CompareTag("SingleBullet"))
            TakeDamage(SingleDamage);
    }

    // Damage function, can be called by other scripts (E.G. Rocket Splash Damage)
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        
    }

}
