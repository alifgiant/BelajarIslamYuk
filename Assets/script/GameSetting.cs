using UnityEngine;
using System.Collections;

public class GameSetting{
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool isLoggerOpenned { get; set;}

	public void setUserName(string value){
		PlayerPrefs.SetString ("email", value);
	}
	
	public string getUserName(){
		return PlayerPrefs.GetString("email", "");
	}

	public void destroyAll(string tag, GameObject sender){
		GameObject [] player = GameObject.FindGameObjectsWithTag (tag);
		foreach (var item in player) {
			//item.SendMessage("destroy")	;
			if (item != sender)
				GameObject.Destroy((GameObject)item);
		}
	}
}
