using UnityEngine;
using System.Collections;

public class moveAwan : MonoBehaviour {

	public int speed;
	public bool comingFromRight;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		if (comingFromRight) {
			transform.position = new Vector2 (transform.position.x - 0.01f*speed, transform.position.y);
			if (transform.position.x <= -11) {
				transform.position = new Vector2 (11, transform.position.y);
			}
		}
		else {
			transform.position = new Vector2 (transform.position.x + 0.01f*speed, transform.position.y);
			if (transform.position.x >= 11) {
				transform.position = new Vector2 (-11, transform.position.y);
			}
		}
	}


}
