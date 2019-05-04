using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pausemenu, pausebutton, homebutton, resumebutton;
   

    private void Start()
    {
    	pausemenu.SetActive(true);
    	pausebutton.SetActive(true);
        pausemenu.SetActive(false);
        
    }

    public void myPause()
    {
    	if (pausemenu.activeInHierarchy == false) {  
            pausemenu.SetActive (true);
            Time.timeScale = 0;
        }
        else                                                  
        {
            pausemenu.SetActive (false);
            Time.timeScale = 1;
        }
        /*
        pausebutton.SetActive(false);
        pausemenu.SetActive(true);
        Time.timeScale = 0;
        */
    }

    public void myResume()
    {
        pausemenu.SetActive(false);
        pausebutton.SetActive(true);
        Time.timeScale = 1;
    }

    public void myHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu2");

    }
}
