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
        Health.health = 10;
        slider = GetComponent<Slider>();

        slider.maxValue = Health.health;


    }

    
    void Update()
    {
       slider.value = Health.health;
    }
}
