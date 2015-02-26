using UnityEngine;
using System.Collections;

public class checkHijaiyahAnswer : MonoBehaviour{
	public Color taken;
	public int[] placedNumber;
	bool[] answered;

	// Use this for initialization
	void Start(){
		placedNumber = new int[10];
		answered = new bool[10];
	}

	public void tookPlaced(int place, int number){
		placedNumber [place] = number;
		answered [place] = false;
	}
	
	public int getPlacedCardNum(){
		if (currentNum < 10){
			if (placedNumber [currentNum]>28) return placedNumber [currentNum]+Random.Range(-1,0);
			else if (placedNumber [currentNum]<1) return placedNumber [currentNum]+Random.Range(0,1);
			else return placedNumber [currentNum]+Random.Range(-1,1);
		}return 0;
	}

	int currentNum = 8;
	public Spawner spaw;
	public endGame end;
	public GameObject optionBar;

	public void checkAnswer(string huruf){
		Debug.Log (currentNum);
		if (currentNum<10){
			Transform temp = transform.GetChild (currentNum);
			if (temp.name.Equals(huruf) && !answered[currentNum]) {
				temp.GetComponent<SpriteRenderer>().color = taken;
				answered[currentNum++] = true;
			}
		}
		if (currentNum>9) {
			Debug.Log("over");
			spaw.isPlayed = false;
			optionBar.SetActive(true);
			end.setWin(true,2);
		}
	}

	public void resetGame(){
		GameSetting settings = new GameSetting();		
		settings.destroyAll("Option",this.gameObject);

		Start (); 
		currentNum = 8;

		GameObject go = GameObject.Find ("EventSystem");
		go.GetComponent<hijaiyahGenerator>().SendMessage ("Start");
		go.GetComponent<Spawner>().reset();
		end.gameObject.SetActive (false);
		optionBar.SetActive (false);
	}

}