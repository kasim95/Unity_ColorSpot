using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver2 : MonoBehaviour
{


    public GameObject GameOverPanel, homebutton;
    public Text Yourscore, Yourhighscore;
    // Start is called before the first frame update
    private ScoreA myA;
    private ScoreB myB;
    private ScoreC myC;
    private AvatarChoice myAV;

    private GameController2 GC;

    void Start()
    {
        GameOverPanel.SetActive(false);
        GC = FindObjectOfType<GameController2>();

        myAV = FindObjectOfType<AvatarChoice>();
        int value = myAV.avchoice;
        if (value == 1)
        { myA = FindObjectOfType<ScoreA>(); }
        else if (value == 2)
        { myB = FindObjectOfType<ScoreB>(); }
        else if (value == 3)
        { myC = FindObjectOfType<ScoreC>(); }
    }


    public void ShowMyMenu()
    {

        GameOverPanel.SetActive(true);

        if (myAV.avchoice == 0 || myAV.avchoice == 1)
        { Yourscore.text = "Score: " + myA.score; }
        else if (myAV.avchoice == 2)
        { Yourscore.text = "Score: " + myB.score; }
        else if (myAV.avchoice == 3)
        { Yourscore.text = "Score: " + myC.score; }
    }

    public void home()
    {

        ///insert code leading back to main screen
    }
}
