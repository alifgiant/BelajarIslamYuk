using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Hit;
using UnityEngine.UI;

public class parentPicker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			reEnabled ();
			isActive = false;
		}
	}

	void OnEnable(){
		//Debug.Log("enabled Tap");
		GetComponent<TapGesture> ().Tapped += HandleTapped;
	}

	void OnDisable(){
		Debug.Log("Disabled tap");
		GetComponent<TapGesture> ().Tapped -= HandleTapped;
	}
	bool isActive = false;
	public void setActive(){
		isActive = true;
	}

	void HandleTapped (object sender, System.EventArgs e)
	{
		Debug.Log("tapped");
		int i = selectedBar.GetComponent<valueHolder> ().counter;
		if (i < 8) {
			GetComponent<SpriteRenderer> ().enabled = false;
			GetComponent<BoxCollider2D> ().enabled = false;
			putThisCardOnSelectedBar (gameObject,i);
		}
	}

	public GameObject selectedCard;
	public Transform selectedBar;
	public int id;

	void putThisCardOnSelectedBar(GameObject a, int i){
		//int i = selectedBar.GetComponent<valueHolder> ().counter;
		Debug.Log (i);
		//if (i < 8) {
			GameObject baru = Instantiate(selectedCard) as GameObject;
			baru.transform.SetParent (selectedBar);

			baru.GetComponent<returnSelected>().setSource(gameObject, id);
			baru.GetComponent<SpriteRenderer>().sortingOrder =7;
			baru.transform.localPosition = new Vector3 (-6.47f+(i*1.82f), -1.47f, 0f);

			selectedBar.GetComponent<valueHolder> ().counter = i+1;
		//}
	}
	void reEnabled(){
		GetComponent<SpriteRenderer> ().enabled = true;
		GetComponent<BoxCollider2D> ().enabled = true;
	}
}
