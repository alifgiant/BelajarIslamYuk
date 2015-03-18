using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float spawnTime;		// The amount of time between each spawn.
	public float spawnDelay;	// The amount of time before spawning starts.
	public GameObject huruf;
	public checkHijaiyahAnswer cheker;
	public PolygonCollider2D hipmiCollider;

	Sprite[] daftarGambar;		// Daftar gambar

	public bool isPlayed = true;
	
	void Start (){				// Use this for initialization
		hipmiCollider.enabled = true;
		daftarGambar = gameObject.GetComponent<hijaiyahGenerator> ().daftarGambar;
		InvokeRepeating ("Spawning", spawnDelay, spawnTime);		
	}

	public void reset(){
		isPlayed = true;
		passedTime = 0f;
	}

	public float initSpeed;

	// Update is called once per frame
	float passedTime;
	void Spawning () {
		if (isPlayed){
			GameObject temp;		// temp object.

			temp = Instantiate (huruf, new Vector2 (-3f, 0f), Quaternion.identity) as GameObject;

			temp.transform.localScale = new Vector2 (1, 1);
			temp.transform.localPosition = new Vector2 (Random.Range (-7, 7), 6.6f);

			int x = cheker.getPlacedCardNum ();
			if (x < 0 || x > 28) {
				x = 4;
			}

			passedTime += Time.deltaTime;

			temp.GetComponent<SpriteRenderer> ().sprite = daftarGambar[x];
			temp.name = "huruf" + x;
			temp.GetComponent<fallingObject> ().setSpeed (passedTime * initSpeed);
			temp.GetComponent<fallingObject> ().isFalling = true;
			temp.transform.SetParent (GameObject.Find ("fallingGroup").transform);
		}
		else{
			Debug.Log("Cancel");
			CancelInvoke("Spawning");
		}
	}
}
