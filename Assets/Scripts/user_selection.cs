using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class user_selection : MonoBehaviour
{

	[System.Serializable]
	public class User
	{
		private string Username;
		private int Lvl1Highscore;
		private int Lvl2Highscore;
		private int Lvl3Highscore;
		private int CoinCount;
		private int SelectedSprite;
		private int SelectedNote;
		private int SelectedBG;
		private bool[] SpritesPurchased = new bool[8];
		private bool[] NotesPurchased = new bool[5];
		private bool[] BGPurchased = new bool[5];
		private bool UserExists;

		public User(string name)
		{
			this.Username = name;
			this.Lvl1Highscore = 0;
			this.Lvl2Highscore = 0;
			this.Lvl3Highscore = 0;
			this.CoinCount = 0;
			this.SelectedSprite = 0;
			this.SelectedNote = 0;
			this.SelectedBG = 0;
		}

		public string uname
		{
			get { return Username; }
			set { Username = value; }
		}

		public int lvl1highscore
		{
			get { return Lvl1Highscore; }
			set { Lvl1Highscore = value; }
		}


		public int lvl2highscore
		{
			get { return Lvl2Highscore; }
			set { Lvl2Highscore = value; }
		}


		public int lvl3highscore
		{
			get { return Lvl3Highscore; }
			set { Lvl3Highscore = value; }
		}


		public int coincount
		{
			get { return CoinCount; }
			set { CoinCount = value; }
		}


		public int selectedsprite
		{
			get { return SelectedSprite; }
			set { SelectedSprite = value; }
		}

		public int selectednote
		{
			get { return SelectedNote; }
			set { SelectedNote = value; }
		}


		public int selectedbg
		{
			get { return SelectedBG; }
			set { SelectedBG = value; }
		}

		public bool[] spritespurchased
		{
			get { return SpritesPurchased; }
			set { SpritesPurchased = value; }
		}

		public bool[] notespurchased
		{
			get { return NotesPurchased; }
			set { NotesPurchased = value; }
		}

		public bool[] bgpurchased
		{
			get { return BGPurchased; }
			set { BGPurchased = value; }
		}
		
		public bool userexists
		{
			get { return UserExists; }
			set { UserExists = value; }
		}

	}


	public Button bt_username1;
	public Button bt_username2;
	public Button bt_username3;
	public Button bt_username4;
	public Button bt_delusername1;
	public Button bt_delusername2;
	public Button bt_delusername3;
	public Button bt_delusername4;
	public Text txt_username1;
	public Text txt_username2;
	public Text txt_username3;
	public Text txt_username4;
	public GameObject panel_user_input;
	public InputField if_username;
	public Button bt_userinput;
	public bool isbtpressed;
	public Button bt_quit;

	public static string folderName = "User_Data";
	public static string folderPath;
	public static string fileExtension = ".dat";

	public static string uname;
	public static int userno;
	public static int lvl1highscore;
	public static int lvl2highscore;
	public static int lvl3highscore;
	public static int coincount;
	public static int selectedsprite;
	public static int selectednote;
	public static int selectedbg;
	//public bool[] spritespurchased = new bool[4];
	//public bool[] notespurchased = new bool[3];
	//public bool[] bgpurchased = new bool[4];

	public User user1;
	public User user2;
	public User user3;
	public User user4;

	
	public static string GetPath(int user_no, string folderPath)
	{
		string dataPath = Path.Combine(folderPath, user_no.ToString() + fileExtension);
		return dataPath;
	}


	void defineUserData()
	{
		User[] user_list = new User[5];
		for (int i = 1; i <= 4; ++i)
        {
        	string dataPath = GetPath(i, folderPath);
        	name = "username" + i.ToString();
        	user_list[i] = new User(name);
			user_list[i].lvl1highscore = 0;
			user_list[i].lvl2highscore = 0;
			user_list[i].lvl3highscore = 0;
			user_list[i].coincount = 1500;
			user_list[i].selectedsprite = 1;
			user_list[i].selectednote = 1;
			user_list[i].selectedbg = 1;
			user_list[i].spritespurchased[1] = true;	
			user_list[i].notespurchased[1] = true;	
			user_list[i].bgpurchased[1] = true;
			user_list[i].userexists = false;	
			for(int j = 2; j <= 7; ++j)
			{
				user_list[i].spritespurchased[j] = false;	
			}
			for (int j = 2; j <= 4; ++j)
			{
				user_list[i].notespurchased[j] = false;		
			}
			for (int j = 2; j <= 4; ++j)
			{
				user_list[i].bgpurchased[j] = false;
			}
			BinaryFormatter bf = new BinaryFormatter();
			using (FileStream fs = File.Open (dataPath, FileMode.OpenOrCreate))
        	{
            	bf.Serialize (fs, user_list[i]);
        	}
        }
        
	}

	public static User Load_Binary(string dataPath)
	{
		BinaryFormatter bfload = new BinaryFormatter();
		using (FileStream fsload = File.Open(dataPath, FileMode.Open))
		{
			 return (User)bfload.Deserialize(fsload);
		}

	}

	public static void Save_PlayerPrefs(int no)
	{
		PlayerPrefs.SetString("current_username", uname);
		PlayerPrefs.SetInt("current_userno", no);	//change this later
		PlayerPrefs.SetInt("current_lvl1highscore", lvl1highscore);
		PlayerPrefs.SetInt("current_lvl2highscore", lvl2highscore);
		PlayerPrefs.SetInt("current_lvl3highscore", lvl3highscore);
		PlayerPrefs.SetInt("current_coincount", coincount);
		PlayerPrefs.SetInt("current_selected_sprite",selectedsprite);
		PlayerPrefs.SetInt("current_selected_note",selectednote);
		PlayerPrefs.SetInt("current_selected_bg",selectedbg);
	}


	//Function everyone will be using in their start function
	public static void Load_PlayerPrefs()
	{
		uname = PlayerPrefs.GetString("current_username");
		userno = PlayerPrefs.GetInt("current_userno");	//change this later
		lvl1highscore = PlayerPrefs.GetInt("current_lvl1highscore");
		lvl2highscore = PlayerPrefs.GetInt("current_lvl2highscore");
		lvl3highscore =  PlayerPrefs.GetInt("current_lvl3highscore");
		coincount = PlayerPrefs.GetInt("current_coincount");
		selectedsprite = PlayerPrefs.GetInt("current_selected_sprite");
		selectednote = PlayerPrefs.GetInt("current_selected_note");
		selectedbg = PlayerPrefs.GetInt("current_selected_bg");

	}


	public static void Save_Binary(User user, int no, string folderPath)
	{
		string dataPath = GetPath(no, folderPath);
		BinaryFormatter bf = new BinaryFormatter();
		using (FileStream fs =File.Open(dataPath, FileMode.OpenOrCreate))
		{
			bf.Serialize (fs, user);
		}
	}

	void makecurrentuser(int no)
	{
		if (no ==1)
		{
			uname = user1.uname;
			lvl1highscore = user1.lvl1highscore;
			lvl2highscore = user1.lvl2highscore;
			lvl3highscore = user1.lvl3highscore;
			coincount = user1.coincount;
			selectedsprite = user1.selectedsprite;
			selectednote = user1.selectednote;
			selectedbg = user1.selectedbg;
		}
		else if (no == 2)
		{
			uname = user2.uname;
			lvl1highscore = user2.lvl1highscore;
			lvl2highscore = user2.lvl2highscore;
			lvl3highscore = user2.lvl3highscore;
			coincount = user2.coincount;
			selectedsprite = user2.selectedsprite;
			selectednote = user2.selectednote;
			selectedbg = user2.selectedbg;
		}
		else if (no == 3)
		{
			uname = user3.uname;
			lvl1highscore = user3.lvl1highscore;
			lvl2highscore = user3.lvl2highscore;
			lvl3highscore = user3.lvl3highscore;
			coincount = user3.coincount;
			selectedsprite = user3.selectedsprite;
			selectednote = user3.selectednote;
			selectedbg = user3.selectedbg;
		}
		else
		{
			uname = user4.uname;
			lvl1highscore = user4.lvl1highscore;
			lvl2highscore = user4.lvl2highscore;
			lvl3highscore = user4.lvl3highscore;
			coincount = user4.coincount;
			selectedsprite = user4.selectedsprite;
			selectednote = user4.selectednote;
			selectedbg = user4.selectedbg;
		}
	}



	void userinputgiven()
	{
		isbtpressed = true;
	}

	IEnumerator WaitforUserInput1()
	{
		while (isbtpressed == false)
		{
			yield return new WaitForSeconds(1f);
		}
		load_uname1_cont();
		StopCoroutine(WaitforUserInput1());
	}

	IEnumerator WaitforUserInput2()
	{
		while (isbtpressed == false)
		{
			yield return new WaitForSeconds(1f);
		}
		load_uname2_cont();
		StopCoroutine(WaitforUserInput2());
	}

	IEnumerator WaitforUserInput3()
	{
		while (isbtpressed == false)
		{
			yield return new WaitForSeconds(1f);
		}
		load_uname3_cont();
		StopCoroutine(WaitforUserInput3());
	}

	IEnumerator WaitforUserInput4()
	{
		while (isbtpressed == false)
		{
			yield return new WaitForSeconds(1f);
		}
		load_uname4_cont();
		StopCoroutine(WaitforUserInput4());
	}


	void load_uname1_cont()
	{
		string name_userinput = if_username.text;
		panel_user_input.SetActive(false);
		user1 = Load_Binary(GetPath(1, folderPath));
		user1.uname = name_userinput;
		//change this later to input for name
		user1.userexists = true;
		Save_Binary(user1, 1, folderPath);
		txt_username1.text = user1.uname;
		bt_delusername1.gameObject.SetActive(true);
		isbtpressed = false;

		uname = user1.uname;
		lvl1highscore = user1.lvl1highscore;
		lvl2highscore = user1.lvl2highscore;
		lvl3highscore = user1.lvl3highscore;
		coincount = user1.coincount;
		selectednote = user1.selectednote;
		selectedsprite = user1.selectedsprite;
		selectedbg = user1.selectedbg;
		Save_PlayerPrefs(1);
		//add code to deactivate the panel
		//change this later to navigate to Home
	}

	void load_uname1()
	{
		isbtpressed = false;
		if (user1.userexists == true)
		{
			makecurrentuser(1);
			Save_PlayerPrefs(1);
			//add code to deactivate this panel
			//panel_user_selection.SetActive(false);
			SceneManager.LoadScene("Menu2");
		}
		else
		{

			if_username.text = "";
			panel_user_input.SetActive(true);
			StartCoroutine(WaitforUserInput1());
			/*string name_userinput = if_username.text;
			user1 = Load_Binary(GetPath(1, folderPath));
			user1.uname = name_userinput;
			//change this later to input for name
			user1.userexists = true;
			Save_Binary(user1, 1, folderPath);
			txt_username1.text = user1.uname;
			bt_delusername1.gameObject.SetActive(true);
			*/
		}


			//panel_user_input.SetActive(false);
	}
	
	void load_uname2_cont()
	{
		string name_userinput = if_username.text;
		panel_user_input.SetActive(false);
		
		user2 = Load_Binary(GetPath(2, folderPath));
		user2.uname = name_userinput;
		user2.userexists = true;
		Save_Binary(user2, 2, folderPath);
		txt_username2.text = user2.uname;
		bt_delusername2.gameObject.SetActive(true);
		isbtpressed = false;	
		Save_Binary(user2, 2, folderPath);

		uname = user2.uname;
		lvl1highscore = user2.lvl1highscore;
		lvl2highscore = user2.lvl2highscore;
		lvl3highscore = user2.lvl3highscore;
		coincount = user2.coincount;
		selectednote = user2.selectednote;
		selectedsprite = user2.selectedsprite;
		selectedbg = user2.selectedbg;
		Save_PlayerPrefs(2);
		//add code to deactivate the panel
		//change this later to navigate to Home
	}

	void load_uname2()
	{
		isbtpressed = false;
		if (user2.userexists == true)
		{
			makecurrentuser(2);
			Save_PlayerPrefs(2);
			//add code to deactivate this panel
			//panel_user_selection.SetActive(false);
			SceneManager.LoadScene("Menu2");
		}
		else
		{
			if_username.text = "";
			panel_user_input.SetActive(true);
			StartCoroutine(WaitforUserInput2());
		}
		isbtpressed = false;
	}

	void load_uname3_cont()
	{
		string name_userinput = if_username.text;
		panel_user_input.SetActive(false);
		
		user3 = Load_Binary(GetPath(3, folderPath));
		user3.uname = name_userinput;
		//change this later tp input for name
		user3.userexists = true;
		Save_Binary(user3, 3, folderPath);
		txt_username3.text = user3.uname;
		bt_delusername3.gameObject.SetActive(true);
		isbtpressed = false;
		uname = user3.uname;
		lvl1highscore = user3.lvl1highscore;
		lvl2highscore = user3.lvl2highscore;
		lvl3highscore = user3.lvl3highscore;
		coincount = user3.coincount;
		selectednote = user3.selectednote;
		selectedsprite = user3.selectedsprite;
		selectedbg = user3.selectedbg;
		Save_PlayerPrefs(3);
		//add code to deactivate the panel
		//change this later to navigate to Home
	}



	void load_uname3()
	{
		isbtpressed = false;
		if (user3.userexists == true)
		{
			makecurrentuser(3);
			Save_PlayerPrefs(3);
			//add code to deactivate this panel
			//panel_user_selection.SetActive(false);
			SceneManager.LoadScene("Menu2");
		}
		else
		{
			if_username.text = "";
			panel_user_input.SetActive(true);
			StartCoroutine(WaitforUserInput3());
		
			}
	}

	void load_uname4_cont()
	{
		string name_userinput = if_username.text;
		panel_user_input.SetActive(false);
		
		user4 = Load_Binary(GetPath(4, folderPath));
		user4.uname = name_userinput;
		//change this later tp input for name
		user4.userexists = true;
		Save_Binary(user4, 4, folderPath);
		txt_username4.text = user4.uname;
		bt_delusername4.gameObject.SetActive(true);
		isbtpressed = false;
		uname = user4.uname;
		lvl1highscore = user4.lvl1highscore;
		lvl2highscore = user4.lvl2highscore;
		lvl3highscore = user4.lvl3highscore;
		coincount = user4.coincount;
		selectednote = user4.selectednote;
		selectedsprite = user4.selectedsprite;
		selectedbg = user4.selectedbg;
		Save_PlayerPrefs(4);
		//add code to deactivate the panel
		//change this later to navigate to Home
	}



	void load_uname4()
	{
		isbtpressed = false;
		if (user4.userexists == true)
		{
			makecurrentuser(4);
			Save_PlayerPrefs(4);
			//add code to deactivate this panel
			//panel_user_selection.SetActive(false);
			SceneManager.LoadScene("Menu2");
		}
		else
		{
			if_username.text = "";
			panel_user_input.SetActive(true);
			StartCoroutine(WaitforUserInput4());
		
			}
	}

	void del_uname1()
	{
		if (user1.userexists == true)
		{
			user1.userexists = false;
			user1.uname = "username1";
			user1.coincount = 1500;
			user1.lvl1highscore = 0;
			user1.lvl2highscore = 0;
			user1.lvl3highscore = 0;
			user1.coincount = 1500;
			user1.selectedsprite = 1;
			user1.selectednote = 1;
			user1.selectedbg = 1;
			user1.spritespurchased[1] = true;	
			user1.notespurchased[1] = true;	
			user1.bgpurchased[1] = true;
			user1.userexists = false;	
			for(int j = 2; j <= 7; ++j)
			{
				user1.spritespurchased[j] = false;	
			}
			for (int j = 2; j <= 4; ++j)
			{
				user1.notespurchased[j] = false;		
			}
			for (int j = 2; j <= 4; ++j)
			{
				user1.bgpurchased[j] = false;
			}
			Save_Binary(user1,1, folderPath);
			txt_username1.text = "<None>";
			bt_delusername1.gameObject.SetActive(false);
		}
	}

	void del_uname2()
	{
		if (user2.userexists == true)
		{
			user2.userexists = false;
			user2.uname = "username2";
			user2.coincount = 1500;
			user2.lvl1highscore = 0;
			user2.lvl2highscore = 0;
			user2.lvl3highscore = 0;
			user2.coincount = 1500;
			user2.selectedsprite = 1;
			user2.selectednote = 1;
			user2.selectedbg = 1;
			user2.spritespurchased[1] = true;	
			user2.notespurchased[1] = true;	
			user2.bgpurchased[1] = true;
			user2.userexists = false;	
			for(int j = 2; j <= 7; ++j)
			{
				user2.spritespurchased[j] = false;	
			}
			for (int j = 2; j <= 4; ++j)
			{
				user2.notespurchased[j] = false;		
			}
			for (int j = 2; j <= 4; ++j)
			{
				user2.bgpurchased[j] = false;
			}
			
			Save_Binary(user2,2, folderPath);
			txt_username2.text = "<None>";
			bt_delusername2.gameObject.SetActive(false);
		}	
	}

	void del_uname3()
	{
		if (user3.userexists == true)
		{
			user3.userexists = false;
			user3.uname = "username3";
			user3.coincount = 1500;
			user3.lvl1highscore = 0;
			user3.lvl2highscore = 0;
			user3.lvl3highscore = 0;
			user3.coincount = 1500;
			user3.selectedsprite = 1;
			user3.selectednote = 1;
			user3.selectedbg = 1;
			user3.spritespurchased[1] = true;	
			user3.notespurchased[1] = true;	
			user3.bgpurchased[1] = true;
			user3.userexists = false;	
			for(int j = 2; j <= 7; ++j)
			{
				user3.spritespurchased[j] = false;	
			}
			for (int j = 2; j <= 4; ++j)
			{
				user3.notespurchased[j] = false;		
			}
			for (int j = 2; j <= 4; ++j)
			{
				user3.bgpurchased[j] = false;
			}
			
			Save_Binary(user3,3, folderPath);
			txt_username3.text = "<None>";
			bt_delusername3.gameObject.SetActive(false);
		}
	
	}

	void del_uname4()
	{
		if (user4.userexists == true)
		{
			user4.userexists = false;
			user4.uname = "username4";
			user4.coincount = 1500;
			user4.lvl1highscore = 0;
			user4.lvl2highscore = 0;
			user4.lvl3highscore = 0;
			user4.coincount = 1500;
			user4.selectedsprite = 1;
			user4.selectednote = 1;
			user4.selectedbg = 1;
			user4.spritespurchased[1] = true;	
			user4.notespurchased[1] = true;	
			user4.bgpurchased[1] = true;
			user4.userexists = false;	
			for(int j = 2; j <= 7; ++j)
			{
				user4.spritespurchased[j] = false;	
			}
			for (int j = 2; j <= 4; ++j)
			{
				user4.notespurchased[j] = false;		
			}
			for (int j = 2; j <= 4; ++j)
			{
				user4.bgpurchased[j] = false;
			}
			
			Save_Binary(user4,4, folderPath);
			txt_username4.text = "<None>";
			bt_delusername4.gameObject.SetActive(false);
		}
	
	}

	void quitgame()
	{
		Application.Quit();
	}

    // Start is called before the first frame update
    void Start()
    {
    	folderPath = Path.Combine(Application.persistentDataPath, folderName);
    	if (!Directory.Exists (folderPath))
        {
        		Directory.CreateDirectory (folderPath);            
        }
        
    	string[] filePaths = Directory.GetFiles(folderPath);
		if (filePaths.Length == 0)
		{
			defineUserData();
		}
		//string data= GetPath(1, folderPath);
		user1 = Load_Binary(GetPath(1, folderPath));
		user2 = Load_Binary(GetPath(2, folderPath));
		user3 = Load_Binary(GetPath(3, folderPath));
		user4 = Load_Binary(GetPath(4, folderPath));
        bt_username1.onClick.AddListener(load_uname1);
		bt_username2.onClick.AddListener(load_uname2);
		bt_username3.onClick.AddListener(load_uname3);
		bt_username4.onClick.AddListener(load_uname4);
		bt_delusername1.onClick.AddListener(del_uname1);
		bt_delusername2.onClick.AddListener(del_uname2);
		bt_delusername3.onClick.AddListener(del_uname3);
		bt_delusername4.onClick.AddListener(del_uname4);
		panel_user_input.SetActive(false);
		bt_userinput.onClick.AddListener(userinputgiven);
		
		if (user1.userexists == false)
		{
			txt_username1.text = "<None>";
			bt_delusername1.gameObject.SetActive(false);
		}
		else
		{
			txt_username1.text = user1.uname;
			bt_delusername1.gameObject.SetActive(true);
		}

		if (user2.userexists == false)
		{
			txt_username2.text = "<None>";
			bt_delusername2.gameObject.SetActive(false);
		}
		else
		{
			txt_username2.text = user2.uname;
			bt_delusername2.gameObject.SetActive(true);
		}

		if (user3.userexists == false)
		{
			txt_username3.text = "<None>";
			bt_delusername3.gameObject.SetActive(false);
		}
		else
		{
			txt_username3.text = user3.uname;
			bt_delusername3.gameObject.SetActive(true);
		}
		if (user4.userexists == false)
		{
			txt_username4.text = "<None>";
			bt_delusername4.gameObject.SetActive(false);
		}
		else
		{
			txt_username4.text = user4.uname;
			bt_delusername4.gameObject.SetActive(true);
		}
		bt_quit.onClick.AddListener(quitgame);
    }

    void Awake()
    {
    			
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
