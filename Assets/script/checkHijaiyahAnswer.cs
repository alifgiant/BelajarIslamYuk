using UnityEngine;
using System.Collections;

public class checkHijaiyahAnswer : MonoBehaviour {
	public Color taken;
	public int[] placedNumber;
	bool[] answered;

	// Use this for initialization
	void Start () {
		placedNumber = new int[10];
		answered = new bool[10];
	}

	public void tookPlaced(int place, int number){
		placedNumber [place] = number;
		answered [place] = false;
	}

	// Update is called once per frame
	void Update () {
	
	}
	public int getPlacedCardNum(){
		if (placedNumber [currentNum]>28) return placedNumber [currentNum]+Random.Range(-1,0);
		else if (placedNumber [currentNum]<1) return placedNumber [currentNum]+Random.Range(0,1);
		else return placedNumber [currentNum]+Random.Range(-1,1);
	}

	int currentNum = 0;
	public Spawner spaw;
	public endGame end;
	public void checkAnswer(string huruf){

		Transform temp = transform.GetChild (currentNum);
		if (temp.name.Equals(huruf) && !answered[currentNum]) {
			temp.GetComponent<SpriteRenderer>().color = taken;
			answered[currentNum++] = true;
			return;
		}
		if (currentNum>9) {
			spaw.isPlayed = false;
			Debug.Log("Over");
		}
	}
}
