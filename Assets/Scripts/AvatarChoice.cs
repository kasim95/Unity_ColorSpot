using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarChoice : MonoBehaviour
{
    public GameObject av1;
    public GameObject av2;
    public GameObject av3;
    public GameObject av4;
    public GameObject av5;
    public GameObject av6;
    public GameObject av7;

    public int avchoice = 0;

    // Start is called before the first frame update
    void Start()
    {
        avchoice = PlayerPrefs.GetInt("current_selected_sprite");

        if (avchoice == 0)
        {
            av1.gameObject.SetActive(true);
            av2.gameObject.SetActive(false);
            av3.gameObject.SetActive(false);
            av4.gameObject.SetActive(false);
            av5.gameObject.SetActive(false);
            av6.gameObject.SetActive(false);
            av7.gameObject.SetActive(false);
        }
        else if (avchoice == 1)
        {
            av1.gameObject.SetActive(true);
            av2.gameObject.SetActive(false);
            av3.gameObject.SetActive(false);
            av4.gameObject.SetActive(false);
            av5.gameObject.SetActive(false);
            av6.gameObject.SetActive(false);
            av7.gameObject.SetActive(false);
        }
        else if (avchoice == 2)
        {
            av1.gameObject.SetActive(false);
            av2.gameObject.SetActive(true);
            av3.gameObject.SetActive(false);
            av4.gameObject.SetActive(false);
            av5.gameObject.SetActive(false);
            av6.gameObject.SetActive(false);
            av7.gameObject.SetActive(false);
        }
        else if (avchoice == 3)
        {
            av1.gameObject.SetActive(false);
            av2.gameObject.SetActive(false);
            av3.gameObject.SetActive(true);
            av4.gameObject.SetActive(false);
            av5.gameObject.SetActive(false);
            av6.gameObject.SetActive(false);
            av7.gameObject.SetActive(false);
        }
        else if (avchoice == 4)
        {
            av1.gameObject.SetActive(false);
            av2.gameObject.SetActive(false);
            av3.gameObject.SetActive(false);
            av4.gameObject.SetActive(true);
            av5.gameObject.SetActive(false);
            av6.gameObject.SetActive(false);
            av7.gameObject.SetActive(false);
        }
        else if (avchoice == 5)
        {
            av1.gameObject.SetActive(false);
            av2.gameObject.SetActive(false);
            av3.gameObject.SetActive(false);
            av4.gameObject.SetActive(false);
            av5.gameObject.SetActive(true);
            av6.gameObject.SetActive(false);
            av7.gameObject.SetActive(false);
        }
        else if(avchoice == 6)
        {
            av1.gameObject.SetActive(false);
            av2.gameObject.SetActive(false);
            av3.gameObject.SetActive(false);
            av4.gameObject.SetActive(false);
            av5.gameObject.SetActive(false);
            av6.gameObject.SetActive(true);
            av7.gameObject.SetActive(false);
        }
        else if(avchoice == 7)
        {
            av1.gameObject.SetActive(false);
            av2.gameObject.SetActive(false);
            av3.gameObject.SetActive(false);
            av4.gameObject.SetActive(false);
            av5.gameObject.SetActive(false);
            av6.gameObject.SetActive(false);
            av7.gameObject.SetActive(true);
        }
    }


}
