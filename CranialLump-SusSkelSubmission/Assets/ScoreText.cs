using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
    TMP_Text text;

    playerKillScore playerKillScore;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        text.text = "Kill Count: 0";
    }
    // Update is called once per frame
    void Update()
    {
        text.text = "Kill Count: " + playerKillScore.Score;
       
    }
}
