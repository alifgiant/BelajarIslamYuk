using UnityEngine;
using System.Collections;

public class fallingObject : MonoBehaviour {
	public float speedMultiplier;
	// Use this for initialization
	void Start () {
		//speedMultiplier = 0;
	}

	public void setSpeed(float y){
		speedMultiplier = y;
	}

	public bool isFalling;
	public int answerLocation;
	public int cardNum;

	// Update is called once per frame
	void Update () {
		if (isFalling) {
			transform.position = new Vector2 (transform.position.x , transform.position.y - (0.02f+speedMultiplier));
			gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
		}			
	}

	void OnTriggerEnter2D (Collider2D col)
	{	
		if(col.gameObject.name == "hipmi"){
			GameObject.Find("panel").GetComponent<checkHijaiyahAnswer>().checkAnswer(transform.name);
		}
		Destroy(this.gameObject);
	}
}
