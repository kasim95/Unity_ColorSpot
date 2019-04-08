using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectMenu : MonoBehaviour
{
    public int myhighscore1 = 0;
    public int myhighscore2 = 0;
    public int myhighscore3 = 0;
    public int wallet =0;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject LV1_rt;
    public GameObject LV2_lft;
    public GameObject LV2_rt;
    public GameObject LV3_lft;
    public Text LV1HighScore;
    public Text LV2HighScore;
    public Text Lv3HighScore;
    public GameObject Homebutton;
    public Text Wallet;
    public Image img_color_wheel;
    public Sprite colorwheel1;
    public Sprite colorwheel2;
    public Sprite colorwheel3;
    //grab data from lv1,lv2,lv3 for highscore

    void Start()
    {
    	Level1.SetActive(true);
        Level2.SetActive(false);
        Level3.SetActive(false);
        LV1_rt.SetActive(true);
        LV2_lft.SetActive(false);
        LV2_rt.SetActive(false);
        LV3_lft.SetActive(false);
        img_color_wheel.sprite = colorwheel1;
        SetWallet();
        updatescores();
    }

    public void firstright()
    {
        Level1.SetActive(false);
        Level2.SetActive(true);
        Level3.SetActive(false);
        LV1_rt.SetActive(false);
        LV2_lft.SetActive(true);
        LV2_rt.SetActive(true);
        LV3_lft.SetActive(false);
        img_color_wheel.sprite = colorwheel2;        
    }

    public void secondleft()
    {
        Level1.SetActive(true);
        Level2.SetActive(false);
        Level3.SetActive(false);
        LV1_rt.SetActive(true);
        LV2_lft.SetActive(false);
        LV2_rt.SetActive(false);
        LV3_lft.SetActive(false);
        img_color_wheel.sprite = colorwheel1;
    }

    public void secondright()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(true);
        LV1_rt.SetActive(false);
        LV2_lft.SetActive(false);
        LV2_rt.SetActive(false);
        LV3_lft.SetActive(true);
        img_color_wheel.sprite = colorwheel3;
    }

    public void thirdleft()
    {
        Level1.SetActive(false);
        Level2.SetActive(true);
        Level3.SetActive(false);
        LV1_rt.SetActive(false);
        LV2_lft.SetActive(true);
        LV2_rt.SetActive(true);
        LV3_lft.SetActive(false);
        img_color_wheel.sprite = colorwheel2;
    }
    public void takemetoLV1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void takemetoLV2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void takemetoLV3()
    {
        SceneManager.LoadScene("Level_3");
    }

    public void takememain()
    {
        //scenemanager to main
    }

    public void updatescores()
    {
        int value = PlayerPrefs.GetInt("current_lvl1highscore");
        if (value != 0)
            LV1HighScore.text = "High Score\n" + PlayerPrefs.GetInt("current_lvl1highscore");
        else
            LV1HighScore.text = "High Score\n" + myhighscore1;

        int value2 = PlayerPrefs.GetInt("current_lvl2highscore");
        if (value2 != 0)
            LV2HighScore.text = "High Score\n" + PlayerPrefs.GetInt("current_lvl2highscore");
        else
            LV2HighScore.text = "High Score\n" + myhighscore2;

        int value3 = PlayerPrefs.GetInt("current_lvl3highscore");
        if (value3 != 0)
            Lv3HighScore.text = "High Score\n" + PlayerPrefs.GetInt("current_lvl3highscore");
        else
            Lv3HighScore.text = "High Score\n" + myhighscore3;
    

    }

    public void SetWallet()
    {
        int val = PlayerPrefs.GetInt("current_coincount");
        if ( val != 0)
            Wallet.text = "" + PlayerPrefs.GetInt("current_coincount");

        else
          Wallet.text = "" + wallet;

    }
}
