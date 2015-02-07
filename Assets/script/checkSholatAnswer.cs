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

	bool isGameEnd;
	public GameObject endPanel;

	public void setWin(bool stat){
		if (stat) {
			Debug.Log ("WIN");
			endPanel.SetActive(true);
			endPanel.GetComponent<endGame>().setWin(true);
		} else {
			Debug.Log ("LOSE");
			endPanel.SetActive(true);
			endPanel.GetComponent<endGame>().setWin(false);
		}
		isGameEnd = true;
	}
}
