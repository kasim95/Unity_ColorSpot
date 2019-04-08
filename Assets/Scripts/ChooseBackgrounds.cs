using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBackgrounds : MonoBehaviour
{

    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public GameObject background4;
    public int bkchoice = 0;

    // Start is called before the first frame update
    void Start()
    {
        bkchoice = PlayerPrefs.GetInt("current_selected_bg");

        if (bkchoice == 0)
        { background1.gameObject.SetActive(true);
            background2.gameObject.SetActive(false);
            background3.gameObject.SetActive(false);
            background4.gameObject.SetActive(false);
        }
        else if (bkchoice == 1)
        {
            background1.gameObject.SetActive(true);
            background2.gameObject.SetActive(false);
            background3.gameObject.SetActive(false);
            background4.gameObject.SetActive(false);
        }
        else if (bkchoice ==2 )
        {
            background1.gameObject.SetActive(false);
            background2.gameObject.SetActive(true);
            background3.gameObject.SetActive(false);
            background4.gameObject.SetActive(false);
        }
        else if(bkchoice == 3)
        {
            background1.gameObject.SetActive(false);
            background2.gameObject.SetActive(false);
            background3.gameObject.SetActive(true);
            background4.gameObject.SetActive(false);
        }
        else if(bkchoice == 4)
        {
            background1.gameObject.SetActive(false);
            background2.gameObject.SetActive(false);
            background3.gameObject.SetActive(false);
            background4.gameObject.SetActive(true);



        }
    }

  
}
