using UnityEngine;
using System.Collections;

public class hijaiyahGenerator : MonoBehaviour {

	public Sprite[] daftarGambar;
	public GameObject itemKartu; //objeckContoh
	//public PolygonCollider2D hipmiCollider;
	int urutKartu;
	
	// Use this for initialization
	void Start () {
		createHuruf ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void createHuruf(){
		for (int i = 0; i < 10; i++) {
			createHurufObject(i,-1);
		}
	}

	public GameObject panel;

	public void changeHuruf(int idHuruf){

		Debug.Log ("Destroy");
		foreach (fallingObject item in panel.GetComponentsInChildren<fallingObject>()) {
			if (item.cardNum == idHuruf) {
				createHurufObject(item.answerLocation, idHuruf);
				Destroy(item.gameObject);
			}
			else if (item.cardNum == 0 && idHuruf == 28) {
				createHurufObject(item.answerLocation, idHuruf);
				Destroy(item.gameObject);
			}
		}
	}

	void createHurufObject(int pos, int dontSelect){
		GameObject item = Instantiate(itemKartu, new Vector2(0f,0f), Quaternion.identity) as GameObject;
		item.transform.localScale = new Vector2(1,1);
		item.transform.localPosition = new Vector2(6.8f - 1.5f*pos ,4.4f);
		do {
			urutKartu = Random.Range (0, 29);
		} while (urutKartu == dontSelect);

		item.name = "huruf"+urutKartu;
		item.GetComponent<fallingObject>().answerLocation = pos;
		item.GetComponent<fallingObject>().cardNum = urutKartu;
		
		panel.GetComponent<checkHijaiyahAnswer>().tookPlaced(pos,urutKartu);
		
		item.GetComponent<SpriteRenderer>().sprite = daftarGambar[urutKartu];
		item.transform.SetParent(GameObject.Find("panel").transform);
	}
}
