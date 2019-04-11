using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class settings : MonoBehaviour
{
	public Button bt_home;
	public Slider slider;
	public float vol;
   
	
	void navigate_toHome()
	{
		SceneManager.LoadScene("Menu2");
	}

	void SetVolume(float vol1)
	{
		AudioListener.volume = vol1;
		PlayerPrefs.SetFloat("volume", vol1);
	}

    // Start is called before the first frame update
    void Start()
    {
    	bt_home.onClick.AddListener(navigate_toHome);
    	
    	if (!PlayerPrefs.HasKey("volume"))
    	{
            PlayerPrefs.SetFloat("volume", 0.7f);

    	}
        float saved_vol = PlayerPrefs.GetFloat("volume");
        slider.value = saved_vol;
        AudioListener.volume = saved_vol;               

        slider.onValueChanged.AddListener(delegate {SetVolume(slider.value); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
