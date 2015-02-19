using UnityEngine;
using System.Collections;

public class hijaiyahGenerator : MonoBehaviour {

	public Sprite[] daftarGambar;
	public GameObject itemKartu; //objeckContoh
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
			GameObject item = Instantiate(itemKartu, new Vector2(0f,0f), Quaternion.identity) as GameObject;
			item.transform.localScale = new Vector2(1,1);
			item.transform.localPosition = new Vector2(6.8f - 1.5f*i ,4.4f);

			urutKartu = Random.Range(0, 29);

			item.name = "huruf"+urutKartu;

			GameObject.Find("panel").GetComponent<checkHijaiyahAnswer>().tookPlaced(i,urutKartu);

			item.GetComponent<SpriteRenderer>().sprite = daftarGambar[urutKartu];
			item.transform.SetParent(GameObject.Find("panel").transform);
		}
	}

}
