using UnityEngine;
using System.Collections;

public class endGame : MonoBehaviour {

	public Sprite win,lose;

	// Use this for initialization
	void Start () {
	}

	public void setWin(bool condition){
		if (condition) 
			gameObject.GetComponent<SpriteRenderer>().sprite = win;
		else
			gameObject.GetComponent<SpriteRenderer>().sprite = lose;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
