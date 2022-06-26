using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sliderHealthbar : MonoBehaviour
{

    protected Health health;
    public Slider slider;

    

    private void Awake()
    {
        //Health.health = 10;
        //enemyHP.currentHP = 100;
        slider = GetComponent<Slider>();

        //slider.maxValue = enemyHP.currentHP;
        //lider.maxValue = Health.health;


    }

    
    void Update()
    {
        //slider.value = enemyHP.currentHP;
       //slider.value = Health.health;
    }
}
