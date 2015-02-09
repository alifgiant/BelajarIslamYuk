using UnityEngine;
using System.Collections;

public class checkSholatAnswer : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		//isAnswer = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public AudioClip trueClip,falseClip;

	public GameObject endPanel;
	public GameObject endOption;


	public void setWin(bool stat){
		endOption.SetActive(true);
		if (stat) {
			Debug.Log ("WIN");
			endPanel.SetActive(true);
			endPanel.GetComponent<endGame>().setWin(true,3);
		} else {
			Debug.Log ("LOSE");
			endPanel.SetActive(true);
			endPanel.GetComponent<endGame>().setWin(false,3);
		}
	}

	public void resetGame(){
		GameSetting settings = new GameSetting();		
		settings.destroyAll("Option",this.gameObject);
		GameObject.Find ("EventSystem").GetComponent<optionLoader>().SendMessage ("Start");
		endPanel.SetActive (false);
		endOption.SetActive (false);
	}
}
