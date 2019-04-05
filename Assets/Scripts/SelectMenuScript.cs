using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuSelect : MonoBehaviour
{

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
    }
    public void takemetoLV1()
    {
        //scene manager to 1
    }

    public void takemetoLV2()
    {
        //scenemanager to 2
    }

    public void takemetoLV3()
    {
        //scenemanager to 3
    }

    public void takememain()
    {
        //scenemanager to main
    }

    public void updatescores()
    {
        //updatescores for LV1,Lv2, Lv3

    }
}
