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
		for (int i = 0; i < cardSource.Length; i++) {
			GameObject item = Instantiate(card, new Vector2(-2.65f+(1.65f*i),-4.2f), Quaternion.identity) as GameObject;
			item.transform.SetParent(this.transform);
			item.transform.localScale = new Vector2(1f,1f);
			//item.transform.localPosition = new Vector2(0f,0f);
			item.GetComponent<SpriteRenderer>().sprite = cardSource[i];
			item.name = (i+1).ToString();
			//item.GetComponent<Image>().sprite = optionSource[i];
			
			//int captured = i+2;
			//item.GetComponent<Button>().onClick.AddListener(() => { MovePage(captured);});
			
			//item.transform.FindChild("Image").GetComponent<Image>().sprite = daftarTulisan[i];
		}
	}

}
