using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	
	public float spawnTime;		// The amount of time between each spawn.
	public float spawnDelay;		// The amount of time before spawning starts.
	public GameObject huruf;
	public checkHijaiyahAnswer cheker;

	Sprite[] daftarGambar;		// Daftar gambar

	public bool isPlayed = true;

	// Use this for initialization
	void Start () {		

		daftarGambar = gameObject.GetComponent<hijaiyahGenerator> ().daftarGambar;

		InvokeRepeating ("Spawning", spawnDelay, spawnTime);		
	}
	
	// Update is called once per frame
	float passedTime;
	void Spawning () {
		GameObject temp;		// temp object.
			
				temp = Instantiate (huruf, new Vector2 (-3f, 0f), Quaternion.identity) as GameObject;

				temp.transform.localScale = new Vector2 (1, 1);
				temp.transform.localPosition = new Vector2 (Random.Range (-7, 7), 6.6f);

				int x = cheker.getPlacedCardNum ();
				Debug.Log("angka " + x);
				if (x<0 || x>28) {
					x=4;
				}
				passedTime += Time.deltaTime;
				//int x = Random.Range(Mathf.Clamp(1,0,daftarGambar.Length),Mathf.Clamp(1,0,daftarGambar.Length));
				
				temp.GetComponent<SpriteRenderer> ().sprite = daftarGambar [x];
				temp.name = "huruf" + x;
				temp.GetComponent<fallingObject>().setSpeed(passedTime*0.02f);
				temp.GetComponent<fallingObject> ().isFalling = true;
				temp.transform.SetParent (GameObject.Find ("fallingGroup").transform);
	
		if (!isPlayed){
			CancelInvoke("Spawning");
		}
	}
}
