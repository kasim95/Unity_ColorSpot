using System.IO;
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
    //public GameObject Homebutton;
    public Text Wallet;
    public Image img_color_wheel;
    public Sprite colorwheel1;
    public Sprite colorwheel2;
    public Sprite colorwheel3;
    public Button bt_home;
    //grab data from lv1,lv2,lv3 for highscore

    public GameObject LV1star1;
    public GameObject LV1star2;
    public GameObject LV1star3;
    public GameObject LV2star1;
    public GameObject LV2star2;
    public GameObject LV2star3;
    public GameObject LV3star1;
    public GameObject LV3star2;
    public GameObject LV3star3;

    public GameObject Red_button;
    public GameObject Blue_button;
    public GameObject Yellow_button;
    public GameObject Orange_button;
    public GameObject Green_button;
    public GameObject Purple_button;
    public GameObject Teal_button;
    public GameObject Amber_button;
    public GameObject Magenta_button;
    public GameObject Red_sign;
    public GameObject Blue_sign;
    public GameObject Yellow_sign;
    public GameObject Orange_sign;
    public GameObject Green_sign;
    public GameObject Purple_sign;
    public GameObject Amber_sign;
    public GameObject Magenta_sign;
    public GameObject Teal_sign;

    public Button bt_quit;
    public GameObject txt_hover_quit;
    public GameObject txt_hover_home;
    public GameObject txt_hover_nextlevel;
    public GameObject txt_hover_previouslevel;

    void Start()
    {
        txt_hover_quit.SetActive(false);
        txt_hover_home.SetActive(false);
        txt_hover_nextlevel.SetActive(false);
        txt_hover_previouslevel.SetActive(false);
    	bt_quit.onClick.AddListener(quit_game);
        bt_home.onClick.AddListener(takememain);
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
        showLV1Stars();
        Red_button.SetActive(true);
        Blue_button.SetActive(true);
        Yellow_button.SetActive(true);
        Orange_button.SetActive(false);
        Green_button.SetActive(false);
        Purple_button.SetActive(false);
        Teal_button.SetActive(false);
        Amber_button.SetActive(false);
        Magenta_button.SetActive(false);
        Red_sign.SetActive(false);
        Blue_sign.SetActive(false);
        Yellow_sign.SetActive(false);
        Orange_sign.SetActive(false);
        Green_sign.SetActive(false);
        Purple_sign.SetActive(false);
        Amber_sign.SetActive(false);
        Magenta_sign.SetActive(false);
        Teal_sign.SetActive(false);

}

	public void quit_game()
	{
		Application.Quit();
	}

    public void bt_quit_onhover()
    {
        txt_hover_quit.SetActive(true);
    }

    public void bt_quit_offhover()
    {
        txt_hover_quit.SetActive(false);
    }

    public void bt_home_onhover()
    {
        txt_hover_home.SetActive(true);
    }

    public void bt_home_offhover()
    {
        txt_hover_home.SetActive(false);
    }

    public void bt_nextlevel_onhover()
    {
        txt_hover_nextlevel.SetActive(true);
    }

    public void bt_nextlevel_offhover()
    {
        txt_hover_nextlevel.SetActive(false);
    }

    public void bt_previouslevel_onhover()
    {
        txt_hover_previouslevel.SetActive(true);
    }

    public void bt_previouslevel_offhover()
    {
        txt_hover_previouslevel.SetActive(false);
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
        showLV2stars();

        Red_button.SetActive(false);
        Blue_button.SetActive(false);
        Yellow_button.SetActive(false);
        Orange_button.SetActive(true);
        Green_button.SetActive(true);
        Purple_button.SetActive(true);
        Teal_button.SetActive(false);
        Amber_button.SetActive(false);
        Magenta_button.SetActive(false);
        txt_hover_nextlevel.SetActive(false);
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

        Red_button.SetActive(true);
        Blue_button.SetActive(true);
        Yellow_button.SetActive(true);
        Orange_button.SetActive(false);
        Green_button.SetActive(false);
        Purple_button.SetActive(false);
        Teal_button.SetActive(false);
        Amber_button.SetActive(false);
        Magenta_button.SetActive(false);
        txt_hover_previouslevel.SetActive(false);
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
        showLV3stars();

        Red_button.SetActive(false);
        Blue_button.SetActive(false);
        Yellow_button.SetActive(false);
        Orange_button.SetActive(false);
        Green_button.SetActive(false);
        Purple_button.SetActive(false);
        Teal_button.SetActive(true);
        Amber_button.SetActive(true);
        Magenta_button.SetActive(true);
        txt_hover_nextlevel.SetActive(false);
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

        Red_button.SetActive(false);
        Blue_button.SetActive(false);
        Yellow_button.SetActive(false);
        Orange_button.SetActive(true);
        Green_button.SetActive(true);
        Purple_button.SetActive(true);
        Teal_button.SetActive(false);
        Amber_button.SetActive(false);
        Magenta_button.SetActive(false);
        txt_hover_previouslevel.SetActive(false);
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
        SceneManager.LoadScene("Menu2");
        //scenemanager to main
    }


    public void show_off()
    {
        Red_sign.SetActive(false);
        Blue_sign.SetActive(false);
        Yellow_sign.SetActive(false);
        Orange_sign.SetActive(false);
        Green_sign.SetActive(false);
        Purple_sign.SetActive(false);
        Amber_sign.SetActive(false);
        Magenta_sign.SetActive(false);
        Teal_sign.SetActive(false);
    }



    public void show_red()
    {
        Red_sign.SetActive(true);
        Blue_sign.SetActive(false);
        Yellow_sign.SetActive(false);
        Orange_sign.SetActive(false);
        Green_sign.SetActive(false);
        Purple_sign.SetActive(false);
        Amber_sign.SetActive(false);
        Magenta_sign.SetActive(false);
        Teal_sign.SetActive(false);
    }

    

    public void show_blue()
    {
        Red_sign.SetActive(false);
        Blue_sign.SetActive(true);
        Yellow_sign.SetActive(false);
        Orange_sign.SetActive(false);
        Green_sign.SetActive(false);
        Purple_sign.SetActive(false);
        Amber_sign.SetActive(false);
        Magenta_sign.SetActive(false);
        Teal_sign.SetActive(false);
    }

    public void show_yellow()
    {
        Red_sign.SetActive(false);
        Blue_sign.SetActive(false);
        Yellow_sign.SetActive(true);
        Orange_sign.SetActive(false);
        Green_sign.SetActive(false);
        Purple_sign.SetActive(false);
        Amber_sign.SetActive(false);
        Magenta_sign.SetActive(false);
        Teal_sign.SetActive(false);
    }

    public void show_orange()
    {
        Red_sign.SetActive(false);
        Blue_sign.SetActive(false);
        Yellow_sign.SetActive(false);
        Orange_sign.SetActive(true);
        Green_sign.SetActive(false);
        Purple_sign.SetActive(false);
        Amber_sign.SetActive(false);
        Magenta_sign.SetActive(false);
        Teal_sign.SetActive(false);
    }

    public void show_green()
    {
        Red_sign.SetActive(false);
        Blue_sign.SetActive(false);
        Yellow_sign.SetActive(false);
        Orange_sign.SetActive(false);
        Green_sign.SetActive(true);
        Purple_sign.SetActive(false);
        Amber_sign.SetActive(false);
        Magenta_sign.SetActive(false);
        Teal_sign.SetActive(false);
    }

    public void show_purple()
    {
        Red_sign.SetActive(false);
        Blue_sign.SetActive(false);
        Yellow_sign.SetActive(false);
        Orange_sign.SetActive(false);
        Green_sign.SetActive(false);
        Purple_sign.SetActive(true);
        Amber_sign.SetActive(false);
        Magenta_sign.SetActive(false);
        Teal_sign.SetActive(false);
    }

    public void show_amber()
    {
        Red_sign.SetActive(false);
        Blue_sign.SetActive(false);
        Yellow_sign.SetActive(false);
        Orange_sign.SetActive(false);
        Green_sign.SetActive(false);
        Purple_sign.SetActive(false);
        Amber_sign.SetActive(true);
        Magenta_sign.SetActive(false);
        Teal_sign.SetActive(false);
    }

    public void show_magenta()
    {
        Red_sign.SetActive(false);
        Blue_sign.SetActive(false);
        Yellow_sign.SetActive(false);
        Orange_sign.SetActive(false);
        Green_sign.SetActive(false);
        Purple_sign.SetActive(false);
        Amber_sign.SetActive(false);
        Magenta_sign.SetActive(true);
        Teal_sign.SetActive(false);
    }

    public void show_teal()
    {
        Red_sign.SetActive(false);
        Blue_sign.SetActive(false);
        Yellow_sign.SetActive(false);
        Orange_sign.SetActive(false);
        Green_sign.SetActive(false);
        Purple_sign.SetActive(false);
        Amber_sign.SetActive(false);
        Magenta_sign.SetActive(false);
        Teal_sign.SetActive(true);
    }

    public void updatescores()
    {
        int value1 = PlayerPrefs.GetInt("current_lvl1highscore");
        if (value1 != 0)
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

    public void showLV1Stars()
    {
        int my1 = PlayerPrefs.GetInt("current_lvl1highscore");
        if (my1 > 0 && my1 <= 20)
        {
            LV1star1.SetActive(true);
            LV1star2.SetActive(false);
            LV1star3.SetActive(false);
        }
        else if (my1 > 20 && my1 <= 50)
        {
            LV1star1.SetActive(false);
            LV1star2.SetActive(true);
            LV1star3.SetActive(false);
        }
        else if(my1 > 50)
        {
            LV1star1.SetActive(false);
            LV1star2.SetActive(false);
            LV1star3.SetActive(true);
        }
        else if (my1 ==0)
        {
            LV1star1.SetActive(false);
            LV1star2.SetActive(false);
            LV1star3.SetActive(false);
        }

    }
    

    public void showLV2stars()
    {
        int my2 = PlayerPrefs.GetInt("current_lvl2highscore");
        if (my2 > 0 && my2 <= 20)
        {
            LV2star1.SetActive(true);
            LV2star2.SetActive(false);
            LV2star3.SetActive(false);
        }
        else if (my2 > 20 && my2 <= 50)
        {
            LV2star1.SetActive(false);
            LV2star2.SetActive(true);
            LV2star3.SetActive(false);
        }
        else if (my2 > 50)
        {
            LV2star1.SetActive(false);
            LV2star2.SetActive(false);
            LV2star3.SetActive(true);
        }
        else if(my2 == 0)
        {
            LV2star1.SetActive(false);
            LV2star2.SetActive(false);
            LV2star3.SetActive(false);
        }

    }

    public void showLV3stars()
    {
        int my3 = PlayerPrefs.GetInt("current_lvl3highscore");
        if (my3 > 0 && my3 <= 20)
        {
            LV3star1.SetActive(true);
            LV3star2.SetActive(false);
            LV3star3.SetActive(false);
        }
        else if (my3 > 20 && my3 <= 50)
        {
            LV3star1.SetActive(false);
            LV3star2.SetActive(true);
            LV3star3.SetActive(false);
        }
        else if (my3 > 50)
        {
            LV3star1.SetActive(false);
            LV3star2.SetActive(false);
            LV3star3.SetActive(true);
        }
        else if(my3 == 0)
        {
            LV3star1.SetActive(false);
            LV3star2.SetActive(false);
            LV3star3.SetActive(false);
        }
    }
}
