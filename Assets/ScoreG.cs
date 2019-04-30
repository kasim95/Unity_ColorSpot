using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreG : MonoBehaviour
{
    public Text scoreText;
    public int ballValue;
    public Text multiplierText;
    public int multivalue;
    public int multicount;

    //public GameObject bonus_button;

    //private ScoreA myA;
    //private ScoreB myB;
    //private ScoreC myC;
    //private ScoreD myD;
    //private ScoreE myE;
    //private ScoreF myF;

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        //bonus_button.SetActive(false);

        //myA = FindObjectOfType<ScoreA>();
        //myB = FindObjectOfType<ScoreB>();
        //myC = FindObjectOfType<ScoreC>();
        //myD = FindObjectOfType<ScoreD>();
        //myE = FindObjectOfType<ScoreE>();
        //myF = FindObjectOfType<ScoreF>();

        //myA.bonus_button.SetActive(false);
        //myB.bonus_button.SetActive(false);
        //myC.bonus_button.SetActive(false);
        //myD.bonus_button.SetActive(false);
        //myE.bonus_button.SetActive(false);
       // myF.bonus_button.SetActive(false);
        
        score = 0;
        multivalue = 1;
        multicount = 0;
        scoreText.text = score.ToString();
        multiplierText.text = multicount.ToString() + "x";
    }

    void OnTriggerEnter2D()
    {
        if (multicount > 30)
        {
            //bonus_button.SetActive(true);

            multivalue = 4;
            multicount += 1;
            score += ballValue * multivalue;
            scoreText.text = score.ToString();
            multiplierText.text = multicount.ToString() + "x";

        }
        else if (multicount >= 20 && multicount <= 30)
        {
            multivalue = 3;
            multicount += 1;
            score += ballValue * multivalue;
            scoreText.text = score.ToString();
            multiplierText.text = multicount.ToString() + "x";
        }
        else if (multicount >= 10 && multicount < 20)
        {

            multivalue = 2;
            multicount += 1;
            score += ballValue * multivalue;
            scoreText.text = score.ToString();
            multiplierText.text = multicount.ToString() + "x";


        }
        else
        {
            //bonus_button.SetActive(false);
            multivalue = 1;
            multicount += multivalue;
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

    //public void bonus()
    //{
    //    bonus_button.SetActive(false);
    //    score += 100;
    //    ResetMultiplier();
    //}
}
