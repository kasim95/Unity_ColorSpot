using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary; 


public class GameController : MonoBehaviour
{

    //Vector2 screenHalfSizeWorldUnits;
    public GameObject[] balls;
    public GameObject[] purses;

    //newstuff
    public GameObject[] ratballs;
    public GameObject[] flames;


    public int nodechoice;
    public float timeLeft;
    public Text timerText;
    public GameObject scorepanel;
    public Button bt_home;
    public GameObject gameoverpanel;
    public Text myscore;
    public Text myhighscore1;
    private ScoreA myA;
    private ScoreB myB;
    private ScoreC myC;

    //newstuff
    private ScoreD myD;
    private ScoreE myE;
    private ScoreF myF;
    private ScoreG myG;


    private AvatarChoice myAV;
    public int highscore1;
    public Text mycoins;
    public int wallet = 0;
    public string folderPath;
    public user_selection.User user;

    public GameObject bonus;

	void Start()

    {
        bonus.SetActive(false);
        highscore1 = PlayerPrefs.GetInt("current_lvl1highscore");
        nodechoice = PlayerPrefs.GetInt("current_selected_note");
        bt_home.onClick.AddListener(navigate_toHome);
        gameoverpanel.SetActive(false);
        myAV = FindObjectOfType<AvatarChoice>();
        int value = myAV.avchoice;
        if (value == 1)
        { myA = FindObjectOfType<ScoreA>(); }
        else if (value == 2)
        { myB = FindObjectOfType<ScoreB>(); }
        else if (value == 3)
        { myC = FindObjectOfType<ScoreC>(); }
        else if (value == 4)
        { myD = FindObjectOfType<ScoreD>(); }
        else if (value == 5)
        { myE = FindObjectOfType<ScoreE>(); }
        else if (value == 6)
        { myF = FindObjectOfType<ScoreF>(); }
        else if (value == 7)
        { myG = FindObjectOfType<ScoreG>(); }

        //screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect* Camera.main.orthographicSize, Camera.main.orthographicSize-1f);
        
        user_selection.Load_PlayerPrefs();
        //nodechoice = user_selection.selectednote;
        if (nodechoice == 1)
        { StartCoroutine(SpawnA()); }
        else if(nodechoice == 2)
        { StartCoroutine(SpawnB()); }
        else if (nodechoice == 3)
        { StartCoroutine(SpawnC()); }
        else if (nodechoice == 4)
        { StartCoroutine(SpawnD()); }
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
        while(timeLeft>0)
        {
            GameObject ball = balls[Random.Range(0, 3)];
            Vector3 spawnPosition = new Vector3(Random.Range(-7.5f, 5f), 10f, 0.0f);
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
            Vector3 spawnPosition = new Vector3(Random.Range(-7.5f, 5f), 10f, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(purse, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));

        }
        yield return new WaitForSeconds(2.0f);
        calcScores();

    }

    IEnumerator SpawnC()
    {
        yield return new WaitForSeconds(3.0f);
        while (timeLeft > 0)
        {
            GameObject ratball = ratballs[Random.Range(0, 3)];
            Vector3 spawnPosition = new Vector3(Random.Range(-7.5f, 5f), 10f, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ratball, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));

        }

        yield return new WaitForSeconds(4.0f);
        calcScores();

    }

    IEnumerator SpawnD()
    {
        yield return new WaitForSeconds(3.0f);
        while (timeLeft > 0)
        {
            GameObject flame = flames[Random.Range(0, 3)];
            Vector3 spawnPosition = new Vector3(Random.Range(-7.5f, 5f), 10f, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(flame, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));

        }

        yield return new WaitForSeconds(4.0f);
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
        {   if (myA.score > 150)
            {
                myA.score += 100;
                myscore.text = "Score: " + myA.score;
                bonus.SetActive(true);
            }
            else
            { myscore.text = "Score: " + myA.score; }
          mycoins.text = "Coins: " + Mathf.RoundToInt(myA.score/2);
            wallet = PlayerPrefs.GetInt("current_coincount");
            wallet += Mathf.RoundToInt(myA.score / 2);
            PlayerPrefs.SetInt("current_coincount", wallet);
            if (myA.score >= highscore1)
            { highscore1 = myA.score;
                //myhighscore1.text = "High Score: " + highscore1;
                PlayerPrefs.SetInt("current_lvl1highscore", highscore1);
            }
        }
        else if (myAV.avchoice == 2)
        {
            if (myB.score > 150)
            {
                myB.score += 100;
                myscore.text = "Score: " + myB.score;
                bonus.SetActive(true);
            }
            else
            { myscore.text = "Score: " + myB.score; }
            mycoins.text = "Coins: " + Mathf.RoundToInt(myB.score / 2);
            wallet = PlayerPrefs.GetInt("current_coincount");
            wallet += Mathf.RoundToInt(myB.score / 2);
            PlayerPrefs.SetInt("current_coincount", wallet);
            if (myB.score >= highscore1)
            {
                highscore1 = myB.score;
               // myhighscore1.text = "High Score: " + highscore1;
               PlayerPrefs.SetInt("current_lvl1highscore", highscore1);
            }
        }
        else if (myAV.avchoice == 3)
        {
            if (myC.score > 150)
            {
                myC.score += 100;
                myscore.text = "Score: " + myC.score;
                bonus.SetActive(true);
            }
            else
            { myscore.text = "Score: " + myC.score; }
            mycoins.text = "Coins: " + Mathf.RoundToInt(myC.score / 2);
            wallet = PlayerPrefs.GetInt("current_coincount");
            wallet += Mathf.RoundToInt(myC.score / 2);
            PlayerPrefs.SetInt("current_coincount", wallet);
            if (myC.score >= highscore1)
            {
                highscore1 = myC.score;
                //myhighscore1.text = "High Score: " + highscore1;
               PlayerPrefs.SetInt("current_lvl1highscore", highscore1);
            }
        }
        else if (myAV.avchoice == 4)
        {
            if (myD.score > 150)
            {
                myD.score += 100;
                myscore.text = "Score: " + myD.score;
                bonus.SetActive(true);
            }
            else
            { myscore.text = "Score: " + myD.score; }
            mycoins.text = "Coins: " + Mathf.RoundToInt(myD.score / 2);
            wallet = PlayerPrefs.GetInt("current_coincount");
            wallet += Mathf.RoundToInt(myD.score / 2);
            PlayerPrefs.SetInt("current_coincount", wallet);
            if (myD.score >= highscore1)
            {
                highscore1 = myD.score;
                //myhighscore1.text = "High Score: " + highscore1;
                PlayerPrefs.SetInt("current_lvl1highscore", highscore1);
            }
        }
        else if (myAV.avchoice == 5)
        {
            if (myE.score > 150)
            {
                myE.score += 100;
                myscore.text = "Score: " + myE.score;
                bonus.SetActive(true);
            }
            else
            { myscore.text = "Score: " + myE.score; }
            mycoins.text = "Coins: " + Mathf.RoundToInt(myE.score / 2);
            wallet = PlayerPrefs.GetInt("current_coincount");
            wallet += Mathf.RoundToInt(myE.score / 2);
            PlayerPrefs.SetInt("current_coincount", wallet);
            if (myE.score >= highscore1)
            {
                highscore1 = myE.score;
                //myhighscore1.text = "High Score: " + highscore1;
                PlayerPrefs.SetInt("current_lvl1highscore", highscore1);
            }
        }
        else if (myAV.avchoice == 6)
        {
            if (myF.score > 150)
            {
                myF.score += 100;
                myscore.text = "Score: " + myF.score + 100;
                bonus.SetActive(true);
            }
            else
            { myscore.text = "Score: " + myF.score; }
            mycoins.text = "Coins: " + Mathf.RoundToInt(myF.score / 2);
            wallet = PlayerPrefs.GetInt("current_coincount");
            wallet += Mathf.RoundToInt(myF.score / 2);
            PlayerPrefs.SetInt("current_coincount", wallet);
            if (myF.score >= highscore1)
            {
                highscore1 = myF.score;
                //myhighscore1.text = "High Score: " + highscore1;
                PlayerPrefs.SetInt("current_lvl1highscore", highscore1);
            }
        }
        else if (myAV.avchoice == 7)
        {
            if (myG.score > 150)
            {
                myG.score += 100;
                myscore.text = "Score: " + myG.score;
                bonus.SetActive(true);
            }
            else
            { myscore.text = "Score: " + myG.score; }
            mycoins.text = "Coins: " + Mathf.RoundToInt(myG.score / 2);
            wallet = PlayerPrefs.GetInt("current_coincount");
            wallet += Mathf.RoundToInt(myG.score / 2);
            PlayerPrefs.SetInt("current_coincount", wallet);
            if (myG.score >= highscore1)
            {
                highscore1 = myG.score;
                //myhighscore1.text = "High Score: " + highscore1;
                PlayerPrefs.SetInt("current_lvl1highscore", highscore1);
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
