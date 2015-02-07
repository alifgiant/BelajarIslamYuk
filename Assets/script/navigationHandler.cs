using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class navigationHandler : MonoBehaviour {
	//public int nextLevel[];
	GameSetting settings;

	// Use this for initialization
	void Start () {
	    settings = new GameSetting ();
		settings.isLoggerOpenned = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
	}

	public void MovePage(int nextLevel){
		Application.LoadLevel(nextLevel);
	}

	#region mode parrent
	public GameObject passPanel;
	public Transform canvas;

	GameObject pass;
	public void openLogger(){
		if (!settings.isLoggerOpenned) {
			pass = Instantiate (passPanel, new Vector3(0f,0f,0f), Quaternion.identity) as GameObject;
			pass.transform.parent = canvas;
			pass.transform.localPosition = new Vector3 (0f, 0f, 0f);
			pass.transform.localScale = new Vector3 (1f, 1f, 1f);
			string userName = settings.getUserName();
			GameObject regis = pass.transform.FindChild("register").gameObject;
			if (!userName.Equals("")) {			
				regis.SetActive(false);
				GameObject log = pass.transform.FindChild("login").gameObject;
				log.GetComponent<Button>().onClick.AddListener(login);
			}
			else {
				regis.GetComponent<Button>().onClick.AddListener(register);
			}
		}
		settings.isLoggerOpenned = true;
	}

	public void closeLogger(){
		Destroy (pass);
		settings.isLoggerOpenned = false;
	}

	void login(){
		string user = pass.transform.FindChild ("InputField").FindChild ("Text").GetComponent<Text> ().text;
		if (user.Equals(settings.getUserName()) ) {
			MovePage(1);
			GameObject.Find("modeCarrier").GetComponent<mode>().setMode(false);
		}
		Debug.Log (user);
	}

	void register(){
		string user = pass.transform.FindChild ("InputField").FindChild ("Text").GetComponent<Text> ().text;
		settings.setUserName (user);
		login ();
		Debug.Log (user);
	}
	#endregion
}