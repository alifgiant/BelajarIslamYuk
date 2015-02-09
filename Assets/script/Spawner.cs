using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	
	public float spawnTime = 3f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject huruf;	// Array of enemy prefabs.
	
	Sprite[] daftarGambar;		// Daftar gambar

	int i = 0;
	
	public void decreaseCounter(int x){
		i -= x;
	}

	// Use this for initialization
	void Start () {		

		daftarGambar = gameObject.GetComponent<hijaiyahGenerator> ().daftarGambar;

		// Start calling the Spawn function repeatedly after a delay .		
		InvokeRepeating ("Spawning", spawnDelay, spawnTime);		
	}
	
	// Update is called once per frame
	void Update () {	
		
		
		
	}
	
	// Update is called once per frame
	void Spawning () {
		GameObject temp;		// temp object.
		if (i <= 10) {			
			temp = Instantiate (huruf, new Vector2 (-3f, 0f), Quaternion.identity) as GameObject;

			temp.transform.localScale = new Vector2 (1, 1);
			temp.transform.localPosition = new Vector2 (Random.Range (-7, 7), 4.4f);

			int x = Random.Range(0,daftarGambar.Length);
			//int x = Random.Range(Mathf.Clamp(1,0,daftarGambar.Length),Mathf.Clamp(1,0,daftarGambar.Length));

			temp.GetComponent<SpriteRenderer> ().sprite = daftarGambar [x];
			temp.name = "huruf"+x;

			temp.GetComponent<fallingObject>().isFalling = true;
			temp.transform.SetParent(GameObject.Find("fallingGroup").transform);
			i++;		
		}		
	}
}
