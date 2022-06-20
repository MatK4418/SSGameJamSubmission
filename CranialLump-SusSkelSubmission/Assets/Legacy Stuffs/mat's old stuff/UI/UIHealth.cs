using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    private Text healthDisplay;
    private GameObject pObject;
    private playerHP importedHP;

    private void Start()
    {
        healthDisplay = GetComponent<Text>();
        pObject = GameObject.Find("PlayerObject");
        importedHP = pObject.GetComponent<playerHP>();
    }
    private void Update()
    {
        
        if (healthDisplay != null)
        {
            healthDisplay.text = importedHP.currentHP.ToString();
        }
    }
}
