using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreDisplay;
    private float score;

    
    void OnEnable()
    {
        score = PlayerPrefs.GetFloat("score");
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score: " + score;
    }
}
