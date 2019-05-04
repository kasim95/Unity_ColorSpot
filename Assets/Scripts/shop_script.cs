using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary; 


[RequireComponent(typeof(Button))]
public class shop_script : MonoBehaviour
{

	//UPDATE: change this later to the current user selected
    //User user1 = Load_User.Create("user1");
    //User newUser = new User("user1");

	public Scrollbar sprites_selection_scrollbar;
	public Scrollbar notes_selection_scrollbar;
	public Scrollbar bg_selection_scrollbar;
	public Button LeftButton;
	public Button RightButton;
	public float Step = 0.1f;
	public Button Sprites; 
	public Button Notes;
	public Button Background;
	public GameObject Notes_panel;
	public GameObject Sprites_panel;
	public GameObject BG_panel;
	public Image object_image;
	public Button bt_toHome;
	public Button bt_purchase;
	public Button bt_select;
	//newUser.coincount = 10000;
	//public int coincount;
	public Text txt_coincount;
	public Text txt_objprice;
	public Text txt_purchasealert;
	public GameObject panel_purchasealert;
	public int object_price;
	//used for keeping track of the object_type and the object_no
	public int current_no1;
	public int current_no2;
	
	public Image object_state;
	public Image star_image;
	public Sprite lock_image;
	public Sprite unlock_image;

	//Object_selection_panel images. Update these images in folder and map them at the end.
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;
	public Sprite sprite5;
	public Sprite sprite6;
	public Sprite sprite7;
	public Sprite note1;
	public Sprite note2;
	public Sprite note3;
	public Sprite note4;
	public Sprite bg1;
	public Sprite bg2;
	public Sprite bg3;
	public Sprite bg4;
	
	//Object_selection_panel Buttons All
	//UPDATE: buttons images according to the object assigned to them.
	public Button bt_sprite1;
	public Button bt_sprite2;
	public Button bt_sprite3;
	public Button bt_sprite4;
	public Button bt_sprite5;
	public Button bt_sprite6;
	public Button bt_sprite7;
	public Button bt_note1;
	public Button bt_note2;
	public Button bt_note3;
	public Button bt_note4;
	public Button bt_bg1;
	public Button bt_bg2;
	public Button bt_bg3;
	public Button bt_bg4;

	public string[] sprites_names = new string[8];
	public int[] sprites_prices = new int[8];
	public string[] notes_names = new string[5];
	public int[] notes_prices = new int[5];
	public string[] bg_names = new string[5];
	public int[] bg_prices = new int[5];
	public Text txt_objectname;
	public user_selection.User user;
	public string folderPath;

	public GameObject txt_selected;
	public GameObject txt_hover_sprites;
	public GameObject txt_hover_notes;
	public GameObject txt_hover_bg;

	public GameObject txt_hover_sprite1;
	public GameObject txt_hover_sprite2;
	public GameObject txt_hover_sprite3;
	public GameObject txt_hover_sprite4;
	public GameObject txt_hover_sprite5;
	public GameObject txt_hover_sprite6;
	public GameObject txt_hover_sprite7;
	public GameObject txt_hover_note1;
	public GameObject txt_hover_note2;
	public GameObject txt_hover_note3;
	public GameObject txt_hover_note4;
	public GameObject txt_hover_bg1;
	public GameObject txt_hover_bg2;
	public GameObject txt_hover_bg3;
	public GameObject txt_hover_bg4;

	
    public void navigate_toHome()
    {
    	//UPDATE: change to Home screen later
    	SceneManager.LoadScene("Menu2");
    }

    void purchase_objectupdate(int no1, int no2)
    {
    	if (no1 == 1)
    	{
    		user.spritespurchased[no2] = true;
    	}
    	else if (no1 == 2)
    	{
    		user.notespurchased[no2] = true;
    	}
    	else if (no1 == 3)
    	{
    		user.bgpurchased[no2] = true;
    	}
    	else
    	{
    		
    	}
   		user_selection.Save_Binary(user, user_selection.userno, folderPath);
    	user_selection.Save_PlayerPrefs(user_selection.userno);
    	checkobjectSelected(no1, no2);
    }

   	public void purchase_object()
   	{
   		if (object_price <= user_selection.coincount)
   		{
   			txt_purchasealert.text = "Object purchased successfully";
   			user_selection.coincount -= object_price;
   			txt_coincount.text = user_selection.coincount.ToString();
   			bt_purchase.gameObject.SetActive(false);
   			bt_select.gameObject.SetActive(true);
   			purchase_objectupdate(current_no1, current_no2);
   		}
   		else
   		{
   			txt_purchasealert.text = "Sorry! You dont have enough coins to purchase.";
   			bt_purchase.gameObject.SetActive(true);
   			bt_select.gameObject.SetActive(false);
   		}
   		panel_purchasealert.SetActive(true);
   		txt_coincount.text = user_selection.coincount.ToString();
   		StartCoroutine(RemoveAfterSeconds(3,panel_purchasealert));

   	}

	public void Increment()
	{
		if (Sprites_panel.activeSelf == true)
		{
			sprites_selection_scrollbar.value +=  Step;
		}
		else if (Notes_panel.activeSelf == true)
		{
			notes_selection_scrollbar.value += Step;
		}
		else
		{
			bg_selection_scrollbar.value += Step;
		}
	}

	public void Decrement()
	{
		if (Sprites_panel.activeSelf== true)
		{
			sprites_selection_scrollbar.value -=  Step;
		}
		else if (Notes_panel.activeSelf == true)
		{
			notes_selection_scrollbar.value -= Step;
		}
		else
		{
			bg_selection_scrollbar.value -= Step;
		}
	}



	public void EnableSprites()
	{
		//change_defaultsprite();
		BG_panel.SetActive(false);
		Notes_panel.SetActive(false);
		Sprites_panel.SetActive(true);

		//code to enable default sprite
		int current_sprite = user_selection.selectedsprite;
    	if (current_sprite == 1)
    	{
    		changeimg_sprite1();
    	}
    	else if (current_sprite == 2)
    	{
    		changeimg_sprite2();
    	}
    	else if (current_sprite == 3)
    	{
    		changeimg_sprite3();
    	}
    	else if (current_sprite == 4)
    	{
    		changeimg_sprite4();
    	}
    	else if (current_sprite == 5)
    	{
    		changeimg_sprite5();
    	}
    	else if (current_sprite == 6)
    	{
    		changeimg_sprite6();
    	}
    	else if (current_sprite == 7)
    	{
    		changeimg_sprite7();
    	}
    	else
    	{
    		changeimg_sprite1();
    	}   
	checkobjectSelected(1,current_sprite);
	}


	public void EnableNotes()
	{
		//change_defaultnote();
		BG_panel.SetActive(false);
		Sprites_panel.SetActive(false);
		Notes_panel.SetActive(true);
		int current_note = user_selection.selectednote;
    	if (current_note == 1)
    	{
    		changeimg_note1();
    	}
    	else if (current_note == 2)
    	{
    		changeimg_note2();
    	}
    	else if (current_note == 3)
    	{
    		changeimg_note3();
    	}
    	else if (current_note == 4)
    	{
    		changeimg_note4();
    	}
    	else
    	{
    		changeimg_note1();
    	}	
	}

	public void EnableBG()
	{
		//change_defaultbg();
		Sprites_panel.SetActive(false);
		Notes_panel.SetActive(false);
		BG_panel.SetActive(true);
		int current_bg = user_selection.selectedbg;
    	if (current_bg == 1)
    	{
    		changeimg_bg1();
    	}
    	else if (current_bg == 2)
    	{
    		changeimg_bg2();
    	}
    	else if (current_bg == 3)
    	{
    		changeimg_bg3();
    	}
    	else if (current_bg == 4)
    	{
    		changeimg_bg4();
    	}
    	else
    	{
    		changeimg_bg1();
    	}
	}

	public void checkobjectSelected(int no1, int no2)
	{
		star_image.enabled = false;
		object_state.enabled = false;
		if (no1 == 1)
		{
			int current_sprite = PlayerPrefs.GetInt("current_selected_sprite");
			if (user.spritespurchased[no2])
			{
				object_state.sprite = unlock_image;
				if (current_sprite == no2)
				{
					star_image.enabled = true;
					object_state.enabled = false;
				}
				else
				{
					star_image.enabled = false;
					object_state.enabled = true;
				}
			}
			else
			{
				star_image.enabled = false;
				object_state.enabled = true;
				object_state.sprite = lock_image;	
			}
		}
		if (no1 == 2)
		{
			int current_note = PlayerPrefs.GetInt("current_selected_note");
			if (user.notespurchased[no2])
			{
				object_state.sprite = unlock_image;
				if (current_note== no2)
				{
					star_image.enabled = true;
					object_state.enabled = false;	
				}
				else
				{
					star_image.enabled = false;
					object_state.enabled = true;
				}				
			}
			else
			{
				star_image.enabled = false;
				object_state.enabled = true;
				object_state.sprite = lock_image;
			}
		}
		if (no1 == 3)
		{
			int current_bg = PlayerPrefs.GetInt("current_selected_bg");
			if (user.bgpurchased[no2])
			{
				object_state.sprite = unlock_image;
				if (current_bg == no2)
				{
					star_image.enabled = true;
					object_state.enabled = false;	
				}
				else
				{
					star_image.enabled = false;
					object_state.enabled = true;
				}				
			}
			else
			{
				star_image.enabled = false;
				object_state.enabled = true;
				object_state.sprite = lock_image;
			}	
		}
	}

	public void EnablePurchaseSelect(int no1, int no2)
	{
		//Here, no1 is for sprites(0), notes(1), bg(2)
		//Here, no2 is for the no of object;
		checkobjectSelected(no1, no2);
		txt_selected.SetActive(false);
		if (no1 == 1)
		{
			int curr_sprite = PlayerPrefs.GetInt("current_selected_sprite");	
			if (!user.spritespurchased[no2])
			{
				bt_select.gameObject.SetActive(false);
				bt_purchase.gameObject.SetActive(true);
			}
			else
			{
				if (curr_sprite == no2)
				{
					bt_purchase.gameObject.SetActive(false);
					bt_select.gameObject.SetActive(false);
					txt_selected.SetActive(true);
				}
				else
				{
					bt_purchase.gameObject.SetActive(false);
					bt_select.gameObject.SetActive(true);
				}
					
			}
		}	
		else if (no1 == 2)
		{
			int curr_note = PlayerPrefs.GetInt("current_selected_note");
			if (!user.notespurchased[no2])
			{
				bt_select.gameObject.SetActive(false);
				bt_purchase.gameObject.SetActive(true);
			}
			else
			{
				if (curr_note == no2)
				{
					bt_purchase.gameObject.SetActive(false);
					bt_select.gameObject.SetActive(false);
					txt_selected.SetActive(true);
				}
				else
				{
					bt_purchase.gameObject.SetActive(false);
					bt_select.gameObject.SetActive(true);
				}
			}
		}
		else if (no1 == 3)
		{
			int curr_bg = PlayerPrefs.GetInt("current_selected_bg");
			if (!user.bgpurchased[no2])
			{
				bt_select.gameObject.SetActive(false);
				bt_purchase.gameObject.SetActive(true);
			}
			else
			{
				if (curr_bg == no2)
				{
					bt_purchase.gameObject.SetActive(false);
					bt_select.gameObject.SetActive(false);
					txt_selected.SetActive(true);
				}
				else
				{
					bt_purchase.gameObject.SetActive(false);
					bt_select.gameObject.SetActive(true);	
				}
				
			}
		}
		else
		{
			bt_purchase.gameObject.SetActive(false);
			bt_select.gameObject.SetActive(false);
		}




	}

	public void changeimg_sprite1()
	{
		current_no1 = 1;
		current_no2 = 1;
		object_image.sprite = sprite1;
		object_price = sprites_prices[1];
		txt_objectname.text = sprites_names[1];
		txt_objprice.text = sprites_prices[1].ToString();
		EnablePurchaseSelect(1, 1);

	}

	public void changeimg_sprite2()
	{
		current_no1 = 1;
		current_no2 = 2;
		object_image.sprite = sprite2;
		object_price = sprites_prices[2];
		txt_objectname.text = sprites_names[2];
		txt_objprice.text = sprites_prices[2].ToString();
		EnablePurchaseSelect(1, 2);
	}
	
	public void changeimg_sprite3()
	{
		current_no1 = 1;
		current_no2 = 3;
		object_image.sprite = sprite3;
		object_price = sprites_prices[3];
		txt_objectname.text = sprites_names[3];
		txt_objprice.text = sprites_prices[3].ToString();
		EnablePurchaseSelect(1, 3);
	}


	public void changeimg_sprite4()
	{
		current_no1 = 1;
		current_no2 = 4;
		object_image.sprite = sprite4;
		object_price = sprites_prices[4];
		txt_objectname.text = sprites_names[4];
		txt_objprice.text = sprites_prices[4].ToString();
		EnablePurchaseSelect(1, 4);
	}

	public void changeimg_sprite5()
	{
		current_no1 = 1;
		current_no2 = 5;
		object_image.sprite = sprite5;
		object_price = sprites_prices[5];
		txt_objectname.text = sprites_names[5];
		txt_objprice.text = sprites_prices[5].ToString();
		EnablePurchaseSelect(1, 5);
	}

	public void changeimg_sprite6()
	{
		current_no1 = 1;
		current_no2 = 6;
		object_image.sprite = sprite6;
		object_price = sprites_prices[6];
		txt_objectname.text = sprites_names[6];
		txt_objprice.text = sprites_prices[6].ToString();
		EnablePurchaseSelect(1, 6);
	}

	public void changeimg_sprite7()
	{
		current_no1 = 1;
		current_no2 = 7;
		object_image.sprite = sprite7;
		object_price = sprites_prices[7];
		txt_objectname.text = sprites_names[7];
		txt_objprice.text = sprites_prices[7].ToString();
		EnablePurchaseSelect(1, 7);
	}

	public void changeimg_note1()
	{
		current_no1 = 2;
		current_no2 = 1;
		object_image.sprite = note1;
		object_price = notes_prices[1];
		txt_objectname.text = notes_names[1];
		txt_objprice.text = notes_prices[1].ToString();
		EnablePurchaseSelect(2, 1);
	}

	public void changeimg_note2()
	{
		current_no1 = 2;
		current_no2 = 2;
		object_image.sprite = note2;
		object_price = notes_prices[2];
		txt_objectname.text = notes_names[2];
		txt_objprice.text = notes_prices[2].ToString();
		EnablePurchaseSelect(2, 2);
	
	}

	public void changeimg_note3()
	{
		current_no1 = 2;
		current_no2 = 3;
		object_image.sprite = note3;
		object_price = notes_prices[3];
		txt_objectname.text = notes_names[3];
		txt_objprice.text = notes_prices[3].ToString();
		EnablePurchaseSelect(2, 3);
	}

	public void changeimg_note4()
	{
		current_no1 = 2;
		current_no2 = 4;
		object_image.sprite = note4;
		object_price = notes_prices[4];
		txt_objectname.text = notes_names[4];
		txt_objprice.text = notes_prices[4].ToString();
		EnablePurchaseSelect(2, 4);
	}

	public void changeimg_bg1()
	{
		current_no1 = 3;
		current_no2 = 1;
		object_image.sprite = bg1;
		object_price = bg_prices[1];
		txt_objectname.text = bg_names[1];
		txt_objprice.text = bg_prices[1].ToString();
		EnablePurchaseSelect(3, 1);
	}

	public void changeimg_bg2()
	{
		current_no1 = 3;
		current_no2 = 2;
		object_image.sprite = bg2;
		object_price = bg_prices[2];
		txt_objectname.text = bg_names[2];
		txt_objprice.text = bg_prices[2].ToString();
		EnablePurchaseSelect(3, 2);
	}

	public void changeimg_bg3()
	{
		current_no1 = 3;
		current_no2 = 3;
		object_image.sprite = bg3;
		object_price = bg_prices[3];
		txt_objectname.text = bg_names[3];
		txt_objprice.text = bg_prices[3].ToString();
		EnablePurchaseSelect(3, 3);
	}

	public void changeimg_bg4()
	{
		current_no1 = 3;
		current_no2 = 4;
		object_image.sprite = bg4;
		object_price = bg_prices[4];
		txt_objectname.text = bg_names[4];
		txt_objprice.text = bg_prices[4].ToString();
		EnablePurchaseSelect(3, 4);
	}

	IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
    	yield return new WaitForSeconds(seconds);
    	obj.SetActive(false);
    }

	void select_object()
	{
		if (current_no1 == 1)
		{
			user.selectedsprite = current_no2;
			user_selection.selectedsprite = current_no2;
		}
		else if (current_no1 == 2)
		{
			user.selectednote = current_no2;
			user_selection.selectednote = current_no2;
		}
		else
		{
			user.selectedbg = current_no2;
			user_selection.selectedbg = current_no2;
		}
		user_selection.Save_PlayerPrefs(user_selection.userno);
		user_selection.Save_Binary(user, user_selection.userno, folderPath);
		checkobjectSelected(current_no1, current_no2);
		EnablePurchaseSelect(current_no1, current_no2);
		
	}

public void onhover_sprite()
{
	txt_hover_sprites.SetActive(true);
}

public void offhover_sprite()
{
	txt_hover_sprites.SetActive(false);
}

public void onhover_notes()
{
	txt_hover_notes.SetActive(true);
}

public void offhover_notes()
{
	txt_hover_notes.SetActive(false);
}

public void onhover_bg()
{
	txt_hover_bg.SetActive(true);
}

public void offhover_bg()
{
	txt_hover_bg.SetActive(false);
}

public void onhover_sprite1()
{
	txt_hover_sprite1.SetActive(true);	
}

public void offhover_sprite1()
{
	txt_hover_sprite1.SetActive(false);	
}

public void onhover_sprite2()
{
	txt_hover_sprite2.SetActive(true);	
}

public void offhover_sprite2()
{
	txt_hover_sprite2.SetActive(false);	
}		

public void onhover_sprite3()
{
	txt_hover_sprite3.SetActive(true);	
}

public void offhover_sprite3()
{
	txt_hover_sprite3.SetActive(false);	
}	

public void onhover_sprite4()
{
	txt_hover_sprite4.SetActive(true);	
}

public void offhover_sprite4()
{
	txt_hover_sprite4.SetActive(false);	
}	

public void onhover_sprite5()
{
	txt_hover_sprite5.SetActive(true);	
}

public void offhover_sprite5()
{
	txt_hover_sprite5.SetActive(false);	
}

public void onhover_sprite6()
{
	txt_hover_sprite6.SetActive(true);	
}

public void offhover_sprite6()
{
	txt_hover_sprite6.SetActive(false);	
}

public void onhover_sprite7()
{
	txt_hover_sprite7.SetActive(true);	
}

public void offhover_sprite7()
{
	txt_hover_sprite7.SetActive(false);	
}

public void onhover_note1()
{
	txt_hover_note1.SetActive(true);	
}

public void offhover_note1()
{
	txt_hover_note1.SetActive(false);	
}


public void onhover_note2()
{
	txt_hover_note2.SetActive(true);	
}

public void offhover_note2()
{
	txt_hover_note2.SetActive(false);	
}


public void onhover_note3()
{
	txt_hover_note3.SetActive(true);	
}

public void offhover_note3()
{
	txt_hover_note3.SetActive(false);	
}


public void onhover_note4()
{
	txt_hover_note4.SetActive(true);	
}

public void offhover_note4()
{
	txt_hover_note4.SetActive(false);	
}


public void onhover_bg1()
{
	txt_hover_bg1.SetActive(true);	
}

public void offhover_bg1()
{
	txt_hover_bg1.SetActive(false);	
}

public void onhover_bg2()
{
	txt_hover_bg2.SetActive(true);	
}

public void offhover_bg2()
{
	txt_hover_bg2.SetActive(false);	
}	

public void onhover_bg3()
{
	txt_hover_bg3.SetActive(true);	
}

public void offhover_bg3()
{
	txt_hover_bg3.SetActive(false);	
}	

public void onhover_bg4()
{
	txt_hover_bg4.SetActive(true);	
}

public void offhover_bg4()
{
	txt_hover_bg4.SetActive(false);	
}				

void decidePricesNames()
{
	//prices and names of sprites, notes and bgs
	sprites_names[1] = "Kirby";
	sprites_prices[1] = 0;
	sprites_names[2] = "Baab";
	sprites_prices[2] = 50;
	sprites_names[3] = "Confused Rat";
	sprites_prices[3] = 50;
	sprites_names[4] = "Git It";
	sprites_prices[4] = 50;
	sprites_names[5] = "Angry Rabbit";
	sprites_prices[5] = 50;
	sprites_names[6] = "Sad Girl";
	sprites_prices[6] = 50;
	sprites_names[7] = "Sword Guy";
	sprites_prices[7] = 50;

	notes_names[1] = "Balls";
	notes_prices[1] = 0;
	notes_names[2] = "Gucci Gang Bags";
	notes_prices[2] = 50;
	notes_names[3] = "Ratballs";
	notes_prices[3] = 50;
	notes_names[4] = "Flames";
	notes_prices[4] = 50;

	bg_names[1] = "Be Mine Blue";
	bg_prices[1] = 0;
	bg_names[2] = "YeeHaw Yellow";
	bg_prices[2] = 50;
	bg_names[3] = "Ree Red";
	bg_prices[3] = 50;
	bg_names[4] = "Starry Sight";
	bg_prices[4] = 50;
}





// Start is called before the first frame update
    void Start()
    {
    	decidePricesNames();
    	txt_selected.SetActive(false);
    	folderPath = Path.Combine(Application.persistentDataPath, user_selection.folderName);
    	bt_purchase.gameObject.SetActive(false);
    	bt_select.gameObject.SetActive(true);
    	user_selection.Load_PlayerPrefs();

    	//Load from Binary code
    	string dataPath = user_selection.GetPath(user_selection.userno, folderPath);
    	user = user_selection.Load_Binary(dataPath);
    	
    	//Initialize the object_selection_panel
    	EnableSprites();
    	
    	txt_coincount.text = user_selection.coincount.ToString();
    	panel_purchasealert.SetActive(false);

    	//Left and Right Buttons for scrollbar
    	LeftButton.onClick.AddListener(Decrement);
    	RightButton.onClick.AddListener(Increment);
    	//Buttons for changing between sprites, notes and bg
    	

    	Sprites.onClick.AddListener(EnableSprites);
    	Notes.onClick.AddListener(EnableNotes);
    	Background.onClick.AddListener(EnableBG);
    	
    	//Listeners for buttons to change image object
    	bt_sprite1.onClick.AddListener(changeimg_sprite1);
       	bt_sprite2.onClick.AddListener(changeimg_sprite2);
    	bt_sprite3.onClick.AddListener(changeimg_sprite3);
    	bt_sprite4.onClick.AddListener(changeimg_sprite4);
    	bt_sprite5.onClick.AddListener(changeimg_sprite5);
    	bt_sprite6.onClick.AddListener(changeimg_sprite6);
    	bt_sprite7.onClick.AddListener(changeimg_sprite7);

    	bt_note1.onClick.AddListener(changeimg_note1);
    	bt_note2.onClick.AddListener(changeimg_note2);
    	bt_note3.onClick.AddListener(changeimg_note3);
    	bt_note4.onClick.AddListener(changeimg_note4);

    	bt_bg1.onClick.AddListener(changeimg_bg1);
    	bt_bg2.onClick.AddListener(changeimg_bg2);
    	bt_bg3.onClick.AddListener(changeimg_bg3);
    	bt_bg4.onClick.AddListener(changeimg_bg4);
    	
    	bt_toHome.onClick.AddListener(navigate_toHome);
    	bt_purchase.onClick.AddListener(purchase_object);
    	bt_select.onClick.AddListener(select_object);
    	

    	txt_hover_sprites.SetActive(false);
    	txt_hover_notes.SetActive(false);
    	txt_hover_bg.SetActive(false);

    	txt_hover_sprite1.SetActive(false);

    	
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}



