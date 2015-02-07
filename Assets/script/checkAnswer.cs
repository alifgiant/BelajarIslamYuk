using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class checkAnswer : MonoBehaviour {

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
		//isAnswer = false;
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

		if (isAnswer) {
			GameObject.Find("EventSystem").GetComponent<optionLoader>().changePlayerState(urutanSholat);
		}
	}


	
}
