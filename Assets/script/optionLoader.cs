using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class optionLoader : MonoBehaviour {

	/// <summary>
	/// Kumpulan gambar sholat dan urutannya
	/// </summary>
	public int[] UrutanSholat2;
	public int[] UrutanSholat3;
	public int[] UrutanSholat4;
	public Sprite[] GambarSholatAll;

	// prefab objek yang bakal dibuat
	public GameObject option;

	//objeck pemain
	public GameObject player;

	// parameter mode Game
	bool soloMode;

	Vector2[] optionLocation;
	bool[] locationTaken;

	// Use this for initialization
	void Start () {
		optionLocation = new Vector2[3];

		currentPhase = 0;
		player.GetComponent<SpriteRenderer> ().sprite = GambarSholatAll [0];

		optionLocation [0] = new Vector2 (-3.61f, 3.18f);
		optionLocation [1] = new Vector2 (1f, 3.18f);
		optionLocation [2] = new Vector2 (5.5f, 3.18f);

		//nanti ganti menjadi baca parameter
		soloMode = true;

		if (soloMode) {
			int jumlahRakaat = Random.Range(0,3);
			Debug.Log("yang terpilih "+jumlahRakaat);
			GameObject jam = GameObject.Find("jamViewer");
			switch (jumlahRakaat) {
				case 0: createAnswerOption(UrutanSholat2);
					jam.GetComponent<Text>().text = "05:00 AM";
					break;
				case 1: createAnswerOption(UrutanSholat3);
					jam.GetComponent<Text>().text = "06:10 PM";
					break;
				case 2: createAnswerOption(UrutanSholat4);
					jam.GetComponent<Text>().text = "12:00 AM"; //Random jamnya antara 12:00, 15:30, 19:10					
					break;
				default: createAnswerOption(UrutanSholat2);
					jam.GetComponent<Text>().text = "05:00 AM";
					break;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {

	}

	//penanda fase sekarang
	int currentPhase;

	void createAnswer(int[] answer){
		int loc = Random.Range (0, 3);
//		try {
	
			GameObject newOpt = Instantiate (option, optionLocation[loc], Quaternion.identity) as GameObject;
			//Debug.Log("objek hadir");
			newOpt.GetComponent<optionPicker> ().setAsAnswer (); //set sebagai jawaban	
			newOpt.GetComponent<optionPicker> ().setUrutanSholat (answer); //memberi tahu urutan berikutnya

			Transform child = newOpt.transform.FindChild("gambar");
			child.GetComponent<SpriteRenderer>().sprite = GambarSholatAll[answer[++currentPhase]];

			Debug.Log ("jawaban "+loc);
			Debug.Log ("sekarang fase "+currentPhase);

			locationTaken [loc] = true;
//		} catch {
//			Debug.Log("Game Berhasi");
//			GameObject.Find("EventSystem").GetComponent<checkSholatAnswer>().setWin(true);
//		}
	}

	void createOption(int[] answer){
		bool[] taken = new bool[GambarSholatAll.Length];
		taken [answer[currentPhase]] = true;
		for (int i = 0; i < 3; i++) {
			if (!locationTaken[i]) {
				GameObject newOpt = Instantiate (option, optionLocation[i], Quaternion.identity) as GameObject;
				int a = selectNumber(taken);
				newOpt.transform.FindChild("gambar").GetComponent<SpriteRenderer>().sprite = GambarSholatAll[a];
				taken[a] = true;
				// menggagalkan load gambar berikutnya
				newOpt.GetComponent<optionPicker> ().setUrutanSholat (null);
			}
		}
	}

	int selectNumber(bool[] taken){
		int i = 0;
		do {
			i = Random.Range(0,taken.Length);
		} while (taken[i]);
		return i;
	}

	void createAnswerOption(int[] source){	
		Debug.Log (source.Length);
		locationTaken = new bool[3];
		try {
			createAnswer (source);
			createOption (source);
		} catch {
			Debug.Log("Game Berhasi");
			GameObject.Find("EventSystem").GetComponent<checkSholatAnswer>().setWin(true);
		}
}

public void changePlayerState(int[] source){
		player.GetComponent<SpriteRenderer> ().sprite = GambarSholatAll[ source [currentPhase]];
		createAnswerOption (source);
	}
}
