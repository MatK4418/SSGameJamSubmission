using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerKillScore : MonoBehaviour
{
    [SerializeField]
    GameObject speedometer, intefaceUI, virticleBackUi, text;
    [SerializeField]
    GameObject[] enemies;


    public static int Score;

    private void Awake()
    {
        speedometer.SetActive(false);
        intefaceUI.SetActive(false);
        virticleBackUi.SetActive(false);
        text.SetActive(false);
    }

    private void Update()
    {
        UISwitchOn();
    }

    // Update is called once per frame
    void UISwitchOn()
    {
        switch (Score)
        {
            case 1:
                text.SetActive(true);
                break;
            case 2:
                speedometer.SetActive(true);
                enemies[0].SetActive(true);
                enemies[1].SetActive(true);
                break;
            case 3:
                virticleBackUi.SetActive(true);
                break;
            case 4:
                intefaceUI.SetActive(true);
                enemies[2].SetActive(true);
                enemies[3].SetActive(true);
                break;
        }
    }
}
