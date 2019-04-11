using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main_menu : MonoBehaviour
{
    public Button bt_start;
    public Button bt_store;
    public Button bt_settings;
    public Button bt_exit;
    public Button bt_userselect;

    void fn_start()
    {
    	SceneManager.LoadScene("Level_Select");
    }

    void fn_store()
    {
    	SceneManager.LoadScene("Shop");
    }

    void fn_settings()
    {
    	SceneManager.LoadScene("Settings");
    }

    void fn_exit()
    {
    	Application.Quit();
    }

    void fn_userselect()
    {
        SceneManager.LoadScene("Load User");
    }


    // Start is called before the first frame update
    void Start()
    {
        bt_start.onClick.AddListener(fn_start);
        bt_store.onClick.AddListener(fn_store);
        bt_settings.onClick.AddListener(fn_settings);
        bt_exit.onClick.AddListener(fn_exit);
        bt_userselect.onClick.AddListener(fn_userselect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
