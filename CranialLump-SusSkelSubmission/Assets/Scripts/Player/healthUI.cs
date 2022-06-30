using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{
    private Text healthDisplay;
    public GameObject playerObject; //Set this in inspector.
    private playerHP hpScript;
    private float importedHP;

    private void Start()
    {
        healthDisplay = GetComponent<Text>();
        hpScript = playerObject.GetComponent<playerHP>();
        importedHP = hpScript.GetComponent<currentPlayerHP>();
    }

    private void Update()
    {
        importedHP = hpScript.GetComponent<currentPlayerHP>();
        if (healthDisplay != null)
        {
            healthDisplay.text = importedHP.ToString();
            Debug.Log("Updated health: " + importedHP);
        }
    }
}