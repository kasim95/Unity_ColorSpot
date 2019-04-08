using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarChoice : MonoBehaviour
{
    public GameObject av1;
    public GameObject av2;
    public GameObject av3;
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
        }
        else if (avchoice == 1)
        {
            av1.gameObject.SetActive(true);
            av2.gameObject.SetActive(false);
            av3.gameObject.SetActive(false);
        }
        else if (avchoice == 2)
        {
            av1.gameObject.SetActive(false);
            av2.gameObject.SetActive(true);
            av3.gameObject.SetActive(false);
        }
        else if (avchoice == 3)
        {
            av1.gameObject.SetActive(false);
            av2.gameObject.SetActive(false);
            av3.gameObject.SetActive(true);
        }
    }


}
