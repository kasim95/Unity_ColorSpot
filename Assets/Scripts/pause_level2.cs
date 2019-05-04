using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause_level2 : MonoBehaviour
{
    public Button bt_quit;
	public Button bt_restart;
	// Start is called before the first frame update
    void Start()
    {
        bt_quit.onClick.AddListener(Quit_Game);
        bt_restart.onClick.AddListener(restart_level2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit_Game()
    {
    	Application.Quit();
    }

    public void restart_level2()
    {
    	SceneManager.LoadScene("Level_2");
    }
}
