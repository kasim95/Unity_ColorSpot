﻿using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary; 


public class GameController2 : MonoBehaviour
{

    Vector2 screenHalfSizeWorldUnits;
    public GameObject[] balls;
    public GameObject[] purses;
    public int nodechoice;
    public float timeLeft;
    public Text timerText;
    public GameObject scorepanel;
    public Button bt_home;
    public GameObject gameoverpanel;
    public Text myscore;
    public Text myhighscore2;
    private ScoreA myA;
    private ScoreB myB;
    private ScoreC myC;
    private AvatarChoice myAV;
    public int highscore2 = 0;
    public Text mycoins;
    public int wallet = 0;
    public string folderPath;
    public user_selection.User user;

    void Start()
    {
        bt_home.onClick.AddListener(navigate_toHome);
        highscore2 = PlayerPrefs.GetInt("current_lvl2highscore");
        nodechoice = PlayerPrefs.GetInt("current_selected_note");

        gameoverpanel.SetActive(false);
        myAV = FindObjectOfType<AvatarChoice>();
        int value = myAV.avchoice;
        if (value == 1)
        { myA = FindObjectOfType<ScoreA>(); }
        else if (value == 2)
        { myB = FindObjectOfType<ScoreB>(); }
        else if (value == 3)
        { myC = FindObjectOfType<ScoreC>(); }


        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        user_selection.Load_PlayerPrefs();
        if (nodechoice == 1)
        { StartCoroutine(SpawnA()); }
        else if (nodechoice == 2)
        { StartCoroutine(SpawnB()); }
        timerText.text = Mathf.RoundToInt(timeLeft).ToString();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        { timeLeft = 0; }
        timerText.text = Mathf.RoundToInt(timeLeft).ToString();
    }

    void navigate_toHome()
    {
        SceneManager.LoadScene("Menu2");
    }

    IEnumerator SpawnA()
    {
        yield return new WaitForSeconds(3.0f);
        while (timeLeft > 0)
        {
            GameObject ball = balls[Random.Range(0, 3)];
            Vector3 spawnPosition = new Vector3(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x - 3f), screenHalfSizeWorldUnits.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));

        }

        yield return new WaitForSeconds(4.0f);
        calcScores();

    }

    IEnumerator SpawnB()
    {
        yield return new WaitForSeconds(3.0f);
        while (timeLeft > 0)
        {
            GameObject purse = purses[Random.Range(0, 3)];
            Vector3 spawnPosition = new Vector3(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x - 3f), screenHalfSizeWorldUnits.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(purse, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));

        }
        yield return new WaitForSeconds(2.0f);
        calcScores();

    }

    public void calcScores()
    {
        gameoverpanel.SetActive(true);
        scorepanel.SetActive(false);
        //public GameObject gameoverpanel;
        //public Text myscore;
        // public Text myhighscore1;

        if (myAV.avchoice == 0 || myAV.avchoice == 1)
        {
            myscore.text = "Score: " + myA.score;
            mycoins.text = "Coins: " + Mathf.RoundToInt(myA.score / 2);
            wallet = PlayerPrefs.GetInt("current_coincount");
            wallet += Mathf.RoundToInt(myA.score / 2);
            PlayerPrefs.SetInt("current_coincount", wallet);
            if (myA.score >= highscore2)
            {
                highscore2 = myA.score;
                //myhighscore2.text = "High Score: " + highscore2;
               PlayerPrefs.SetInt("current_lvl2highscore", highscore2);
            }
        }
        else if (myAV.avchoice == 2)
        {
            myscore.text = "Score: " + myB.score;
            mycoins.text = "Coins: " + Mathf.RoundToInt(myB.score / 2);
            wallet = PlayerPrefs.GetInt("current_coincount");
            wallet += Mathf.RoundToInt(myB.score / 2);
            PlayerPrefs.SetInt("current_coincount", wallet);
            if (myB.score >= highscore2)
            {
                highscore2 = myB.score;
                //myhighscore2.text = "High Score: " + highscore2;
                PlayerPrefs.SetInt("current_lvl2highscore", highscore2);
            }
        }
        else if (myAV.avchoice == 3)
        {
            myscore.text = "Score: " + myC.score;
            mycoins.text = "Coins: " + Mathf.RoundToInt(myC.score / 2);
            wallet = PlayerPrefs.GetInt("current_coincount");
            wallet += Mathf.RoundToInt(myC.score / 2);
            PlayerPrefs.SetInt("current_coincount", wallet);
            if (myC.score >= highscore2)
            {
                highscore2 = myC.score;
                myhighscore2.text = "High Score: " + highscore2;
                PlayerPrefs.SetInt("current_lvl2highscore", highscore2);
            }
        }
    //Load from Binary code
    folderPath = Path.Combine(Application.persistentDataPath, user_selection.folderName);
    int userno = PlayerPrefs.GetInt("current_userno");   
    string dataPath = user_selection.GetPath(userno, folderPath);
    user = user_selection.Load_Binary(dataPath);
    user.coincount = PlayerPrefs.GetInt("current_coincount");
    user.lvl1highscore = PlayerPrefs.GetInt("current_lvl1highscore");
    user.lvl2highscore = PlayerPrefs.GetInt("current_lvl2highscore");
    user.lvl3highscore = PlayerPrefs.GetInt("current_lvl3highscore");
    user_selection.Save_Binary(user, userno, folderPath);
    }

}
