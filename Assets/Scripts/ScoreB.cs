using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreB : MonoBehaviour
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
        scoreText.text = score.ToString();
        multiplierText.text = multicount.ToString() + "x";
    }

    void OnTriggerEnter2D()
    {
        if (multicount >= 10)
        {
            multivalue = 2;
            multicount = 10;
            score += ballValue * multivalue;
            scoreText.text = score.ToString();
            multiplierText.text = multicount.ToString() + "x";
        }
        else
        {

            multicount += 1;
            score += ballValue * multivalue;
            scoreText.text = score.ToString();
            multiplierText.text = multicount.ToString() + "x";

        }
    }


    public void ResetMultiplier()
    {
        multicount = 0;
        multiplierText.text = multicount.ToString() + "x";

    }

   
}
