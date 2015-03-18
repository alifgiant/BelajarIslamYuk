using UnityEngine;
using UnityEngine.UI;
using TouchScript.Gestures;
using TouchScript.Hit;
using System.Collections;


public class returnSelected : MonoBehaviour {
	private GameObject source;

	public int id;

	public void setSource(GameObject src, int id){
		this.id = id;
		source = src;
		GetComponent<SpriteRenderer> ().sprite = src.GetComponent<SpriteRenderer>().sprite;
	}
	void OnEnable(){
		GetComponent<TapGesture>().Tapped += HandleTapped;
	}

	void OnDisable(){
		GetComponent<TapGesture> ().Tapped -= HandleTapped;
	}
	
	void HandleTapped (object sender, System.EventArgs e){
		source.GetComponent<parentPicker> ().setActive ();
		GameObject.Find("selectedBar").GetComponent<valueHolder> ().counter--;
		Destroy (gameObject);
	}
}
