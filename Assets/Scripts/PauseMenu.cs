using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu, pausebutton, homebutton, resumebutton;

    private void Start()
    {
        pausemenu.SetActive(false);
        pausebutton.SetActive(true);

    }
    

    public void myPause()
    {
        pausemenu.SetActive(true);
        pausebutton.SetActive(false);
        Time.timeScale = 0;
    }

    public void myResume()
    {
        pausemenu.SetActive(false);
        pausebutton.SetActive(true);
        Time.timeScale = 1;
    }

    public void myHome()
    {

        ///insert code leading back to main screen
    }
}
