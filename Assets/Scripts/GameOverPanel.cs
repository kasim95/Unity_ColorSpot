using System.Collections;
using System.Collections.Generic;
using UnityEngine;



using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public void homebutton()
    {
        SceneManager.LoadScene("Level_Select");

    }
}
