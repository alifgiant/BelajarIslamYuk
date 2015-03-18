using UnityEngine;
using System.Collections;

public class cardGenerator : MonoBehaviour {

	public Sprite[] cardSource;
	public GameObject card;

	// Use this for initialization
	void Start () {
		createCards ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void createCards(){
		bool[] taken = new bool[cardSource.Length];			
		for (int i = 0; i < cardSource.Length; i++) {
			GameObject item = Instantiate (card, new Vector2 (-2.65f + (1.65f * i), -4.2f), Quaternion.identity) as GameObject;
			item.transform.SetParent (this.transform);
			item.transform.localScale = new Vector2 (1f, 1f);

			//pengrandom kartu yang muncul
			int a = selectNumber (taken);
			taken [a] = true;
			item.GetComponent<SpriteRenderer> ().sprite = cardSource [a];
			item.name = (a).ToString ();
		}
	}

	int selectNumber(bool[] taken){
		int i = 0;
		do {
			i = Random.Range(0,taken.Length);
		} while (taken[i]);
		return i;
	}

}
