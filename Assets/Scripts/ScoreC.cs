﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreC : MonoBehaviour
{
    public Text scoreText;
    public int ballValue;
    public Text multiplierText;
    public int multivalue;
    public int multicount;

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        multivalue = 1;
        multicount = 0;
        scoreText.text = "Score: \n" + score;
        multiplierText.text = "Multiplier \n" + multicount;
    }

    void OnTriggerEnter2D()
    {
        if (multicount >= 10)
        {
            multivalue = 2;
            multicount = 10;
            score += ballValue * multivalue;
            scoreText.text = "Score: \n" + score;
            multiplierText.text = "Multiplier \n" + multicount;
        }
        else
        {

            multicount += 1;
            score += ballValue * multivalue;
            scoreText.text = "Score: \n" + score;
            multiplierText.text = "Multiplier \n" + multicount;

        }
    }


    public void ResetMultiplier()
    {
        multicount = 0;
        multiplierText.text = "Multiplier \n" + multicount;

    }

    
}