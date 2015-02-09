using UnityEngine;
using System.Collections;

public class checkHijaiyahAnswer : MonoBehaviour {
	public Color taken;
	public int[] placedNumber;

	// Use this for initialization
	void Start () {
		placedNumber = new int[10];
	}

	public void tookPlaced(int place, int number){
		placedNumber [place] = number;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void checkAnswer(string huruf){
		foreach (Transform item in transform) {
			if (item.name.Equals(huruf)){
				item.GetComponent<SpriteRenderer>().color = taken;
				return;
			}
		}
	}
}
