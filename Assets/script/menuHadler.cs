using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuHadler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		createMenuItem ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	public Sprite[] daftarGambar;
	public Sprite[] daftarTulisan;
	public GameObject menuItem;
	
	void createMenuItem(){

		for (int i = 0; i < daftarGambar.Length; i++) {
			GameObject item = Instantiate(menuItem, new Vector2(0f,0f), Quaternion.identity) as GameObject;
			item.transform.SetParent(this.transform);
			item.transform.localScale = new Vector2(1f,1f);
			item.transform.localPosition = new Vector2((-500f)+(i*330f),18f);
			item.GetComponent<Image>().sprite = daftarGambar[i];

			int captured = i+2;
			item.GetComponent<Button>().onClick.AddListener(() => { MovePage(captured);});

			item.transform.FindChild("Image").GetComponent<Image>().sprite = daftarTulisan[i];
		}
	}

	void MovePage(int nextLevel){
		Application.LoadLevel(nextLevel);
	}

}
