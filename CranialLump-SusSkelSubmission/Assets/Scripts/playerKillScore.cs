using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerKillScore : MonoBehaviour
{
    [SerializeField]
    GameObject speedometer, intefaceUI, virticleBackUi, text, endScreen;
    [SerializeField]
    GameObject[] enemies;


    public static int Score;

    private void Awake()
    {
        speedometer.SetActive(false);
        intefaceUI.SetActive(false);
        virticleBackUi.SetActive(false);
        text.SetActive(false);
        endScreen.SetActive(false);
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
            case 5:

                break;
            case 6:
                enemies[4].SetActive(true);
                enemies[5].SetActive(true);

                break;
            case 7:

                break;
            case 8:
                enemies[6].SetActive(true);
                enemies[7].SetActive(true);


                break;
            case 9:

                break;
            case 10:
                enemies[8].SetActive(true);
                enemies[9].SetActive(true);
                break;
            case 11:

                break;
            case 12:
                enemies[10].SetActive(true);
                enemies[11].SetActive(true);
                break;
            case 14:
                endScreen.SetActive(true);
                break;
        }
    }
}
