using UnityEngine;
using System.Collections;

public class modeDetection : MonoBehaviour {

	GameObject modeCarrier;
	// Use this for initialization
	void Start () {
		modeCarrier = GameObject.Find("modeCarrier");		
		changeNameBar ();
	}

	public Sprite solo,parrent;
	void changeNameBar(){
		GameObject nameBar = GameObject.Find("modeName");
		if (nameBar != null && modeCarrier != null){
			if (modeCarrier.GetComponent<mode>().getMode()){
				nameBar.GetComponent<SpriteRenderer>().sprite = solo;
			}else{
				nameBar.GetComponent<SpriteRenderer>().sprite = parrent;
			}
		}	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
