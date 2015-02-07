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

		optionLocation [0] = new Vector2 (-3.61f, 3.18f);
		optionLocation [1] = new Vector2 (1f, 3.18f);
		optionLocation [2] = new Vector2 (5.5f, 3.18f);

		//nanti ganti menjadi baca parameter
		soloMode = true;

		if (soloMode) {
			int jumlahRakaat = Random.Range(0,3);
			Debug.Log("yang terpilih "+jumlahRakaat);

			switch (jumlahRakaat) {
				case 0: createAnswerOption(UrutanSholat2);
					break;
				case 1: createAnswerOption(UrutanSholat3);
					break;
				case 2: createAnswerOption(UrutanSholat4);
					break;
				default: createAnswerOption(UrutanSholat2);
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
		try {
	
			GameObject newOpt = Instantiate (option, optionLocation[loc], Quaternion.identity) as GameObject;
		//		Debug.Log("objek hadir");
			newOpt.GetComponent<checkAnswer> ().setAsAnswer (); //set sebagai jawaban	
			newOpt.GetComponent<checkAnswer> ().setUrutanSholat (answer); //memberi tahu urutan berikutnya

			Transform child = newOpt.transform.FindChild("gambar");
			child.GetComponent<SpriteRenderer>().sprite = GambarSholatAll[answer[++currentPhase]];

			Debug.Log ("jawaban "+loc);
			Debug.Log ("sekarang fase "+currentPhase);

			locationTaken [loc] = true;
		} catch {
			Debug.Log("Game Berhasi");
		}
	}

	void createOption(){
		for (int i = 0; i < 3; i++) {
			if (!locationTaken[i]) {
				GameObject newOpt = Instantiate (option, optionLocation[i], Quaternion.identity) as GameObject;
				newOpt.transform.FindChild("gambar").GetComponent<SpriteRenderer>().sprite = GambarSholatAll[Random.Range(0,7)];

				// menggagalkan load gambar berikutnya
				newOpt.GetComponent<checkAnswer> ().setUrutanSholat (null);
			}
		}
	}

	void createAnswerOption(int[] source){	
		Debug.Log (source.Length);
		locationTaken = new bool[3];
		createAnswer (source);
		createOption ();
	}

	public void changePlayerState(int[] source){
		player.GetComponent<SpriteRenderer> ().sprite = GambarSholatAll[ source [currentPhase]];
		createAnswerOption (source);
	}
}
