using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class optionPicker : MonoBehaviour {

	bool isAnswer;
	int[] urutanSholat;

	public void setAsAnswer(){
		isAnswer = true;
	}
	
	public void setUrutanSholat(int[] source){
		urutanSholat = source;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnEnable(){
		GetComponent<TapGesture>().Tapped += HandleTapped;
	}
	
	void OnDisable(){
		GetComponent<TapGesture>().Tapped -= HandleTapped;
	}
	
	void HandleTapped (object sender, System.EventArgs e)
	{
		GameSetting settings = new GameSetting();
		
		settings.destroyAll("Option",this.gameObject);
		
		Destroy (this.gameObject);

		GameObject eventSystem = GameObject.Find ("EventSystem");
		if (isAnswer) {
			eventSystem.GetComponent<optionLoader> ().changePlayerState (urutanSholat);
			eventSystem.audio.clip = eventSystem.GetComponent<checkSholatAnswer> ().trueClip;
			eventSystem.audio.Play ();
		} else {
			eventSystem.audio.clip = eventSystem.GetComponent<checkSholatAnswer> ().falseClip;
			eventSystem.audio.Play ();
			eventSystem.GetComponent<checkSholatAnswer>().setWin(false);
		}
	}
}
