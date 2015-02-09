using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class endGame : MonoBehaviour {

	public Sprite win,lose;

	// Use this for initialization
	void Start () {
	}

	public void setWin(bool condition, int page){
		if (condition) {
			GameObject.Find ("endText1").GetComponent<Text> ().text = "HORE!!";
			GameObject.Find ("endText2").GetComponent<Text> ().text = "MAIN LAGI?";

			switch (page) {
			case 1: 
				GameObject.Find ("endText3").GetComponent<Text> ().text = "SEMUA URUTAN BENAR";
				break;
			case 2: 
				GameObject.Find ("endText3").GetComponent<Text> ().text = "SEMUA URUTAN BENAR";
				break;
			case 3: 
				GameObject.Find ("endText3").GetComponent<Text> ().text = "URUTAN SHOLATMU BENAR";
				break;
			default:
				break;
			}

			gameObject.GetComponent<SpriteRenderer> ().sprite = win;
		} else {
			GameObject.Find ("endText1").GetComponent<Text> ().text = "UPSS..";
			GameObject.Find ("endText2").GetComponent<Text> ().text = "COBA LAGI?";
			switch (page) {
			case 1: 
				GameObject.Find ("endText3").GetComponent<Text> ().text = "ADA URUTAN YANG SALAH";
				break;
			case 2: 
				GameObject.Find ("endText3").GetComponent<Text> ().text = "SEMUA URUTAN SALAH";
				break;
			case 3: 
				GameObject.Find ("endText3").GetComponent<Text> ().text = "URUTAN SHOLATMU SALAH";
				break;
			default:
				break;
			}
			gameObject.GetComponent<SpriteRenderer> ().sprite = lose;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
