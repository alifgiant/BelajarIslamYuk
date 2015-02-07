using UnityEngine;
using System.Collections;

public class mode : MonoBehaviour {

	public bool isSolo;

	public bool getMode(){
		return isSolo;
	}

	public void setMode(bool set){
		isSolo = set;
	}

	// Use this for initialization
	void Start () {
		isSolo = true;
		DontDestroyOnLoad (gameObject);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
