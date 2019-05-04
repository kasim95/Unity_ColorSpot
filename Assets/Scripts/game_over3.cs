using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class game_over3 : MonoBehaviour
{
    public Button bt_quit;
	public Button bt_restart;
    // Start is called before the first frame update
    void Start()
    {
        bt_quit.onClick.AddListener(quit_game);
        bt_restart.onClick.AddListener(restart_level3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quit_game()
    {
    	Application.Quit();
    }

    public void restart_level3()
    {
    	SceneManager.LoadScene("Level_3");
    }
}
