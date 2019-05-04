using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class pause_level3 : MonoBehaviour
{
    public Button bt_quit;
	public Button bt_restart;
	// Start is called before the first frame update
    void Start()
    {
        bt_quit.onClick.AddListener(Quit_Game);
        bt_restart.onClick.AddListener(restart_level3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit_Game()
    {
    	Application.Quit();
    }

    public void restart_level3()
    {
    	SceneManager.LoadScene("Level_3");
    }
}
