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
		GameObject [] player = GameObject.FindGameObjectsWithTag ("Player");
		foreach (var item in player) {
			//item.SendMessage("destroy")	;
			if (item != null)
				item.SendMessage("returnToInit");
		}
		isGameEnd = false;
	}

	bool isGameEnd;

	public GameObject endPanel;
	void checkAnswer(){
		bool correctAnswer = true;
		for (int i = 0; i < 8; i++) {
			if (cardOrder[i]!=i) 
				correctAnswer = false;
		}
		if (correctAnswer) {
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

	public GameObject panel; //sure panel
	void closeSureBar(){
		panel.SetActive (false);
	}

	void showSureBar(){
		panel.SetActive (true);
	}
}
