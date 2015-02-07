using UnityEngine;
using System.Collections;

public class hipmiMovement : MonoBehaviour {
	float yPosition;
	// Use this for initialization
	void Start () {
		yPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x, yPosition);
	}
}
