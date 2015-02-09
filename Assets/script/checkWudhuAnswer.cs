using UnityEngine;
using System.Collections;

public class checkWudhuAnswer : MonoBehaviour {

	int[] takenPlace;
	public int[] cardOrder;

	// Use this for initialization
	void Start () {
		takenPlace = new int[8];
		cardOrder = new int[8];
	}

	public void tookPlace(int slot, int cardNumber){
		//takenPlace [slot]++;
		if (takenPlace [slot]++ <1) {
			cardOrder[slot] = cardNumber;
		}
	}

	public void releasePlace(int slot){
		takenPlace [slot]--;
	}

	// Update is called once per frame
	void Update () {
		int answerCounter = 0;
		for (int i = 0; i < 8; i++) {
			if (takenPlace[i]>0) answerCounter++;
		}
		if (answerCounter > 7 && !isGameEnd)
						showSureBar ();
				else
						closeSureBar ();
	}

	void resetAnswer(){
		GameObject [] player = GameObject.FindGameObjectsWithTag ("Option");
		foreach (var item in player) {
			//item.SendMessage("destroy")	;
			if (item != null)
				item.SendMessage("returnToInit");
		}
		isGameEnd = false;
	}

	bool isGameEnd;

	public GameObject endPanel;
	public GameObject endOption;

	void checkAnswer(){
		bool correctAnswer = true;
		for (int i = 0; i < 8; i++) {
			if (cardOrder[i]!=i) 
				correctAnswer = false;
		}
		endPanel.SetActive(true);
		endOption.SetActive(true);
		if (correctAnswer) {
			Debug.Log ("WIN");
			endPanel.GetComponent<endGame>().setWin(true,1);
		} else {
			Debug.Log ("LOSE");
			endPanel.GetComponent<endGame>().setWin(false,1);
		}
		isGameEnd = true;
	}

	public void resetGame(){
		GameSetting settings = new GameSetting();		
		settings.destroyAll("Option",this.gameObject);
		GameObject.Find ("optionBar").GetComponent<cardGenerator>().SendMessage ("Start");
		endPanel.SetActive (false);
		endOption.SetActive (false);
		takenPlace = new int[8];
		isGameEnd = false;
	}

	public GameObject panel; //sure panel
	void closeSureBar(){
		panel.SetActive (false);
	}

	void showSureBar(){
		panel.SetActive (true);
	}
}
