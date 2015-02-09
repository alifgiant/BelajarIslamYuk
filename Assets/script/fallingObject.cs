using UnityEngine;
using System.Collections;

public class fallingObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	public bool isFalling;

	// Update is called once per frame
	void Update () {
		if (isFalling) {
			transform.position = new Vector2 (transform.position.x , transform.position.y - 0.02f );
			gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
		}			
	}

	void OnTriggerEnter2D (Collider2D col)
	{	
		if(col.gameObject.name == "hipmi")
		{
			GameObject.Find("EventSystem").GetComponent<Spawner>().decreaseCounter(1);
			GameObject.Find("panel").GetComponent<checkHijaiyahAnswer>().checkAnswer(transform.name);
		}
		Destroy(this.gameObject);
	}
}
