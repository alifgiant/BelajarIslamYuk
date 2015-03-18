using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Hit;

public class dragObject : MonoBehaviour {

//	private float dist;
//	private Transform toDrag;

	private GameObject placeNum;
	private Vector3 initPlace;

//	private bool dragging = false;
//	private Vector3 offset;
//	
//	//var posisi sentuhan ke layar
//	public Vector3 v3;
//	
//	private bool played;
//	RuntimePlatform platform = Application.platform;

	// Use this for initialization
	void Start () {
		placeNum = null;
	}

	void OnEnable(){
		Debug.Log("enabled");
		GetComponent<ReleaseGesture>().Released += HandleReleased;
		initPlace = new Vector3(transform.localPosition.x,transform.localPosition.y);
	}

	void HandleReleased (object sender, System.EventArgs e)
	{
		Debug.Log("released");
		placeObject();
	}	

	void OnDisable(){
		Debug.Log("Disabled");
		GetComponent<ReleaseGesture>().Released -= HandleReleased;
	}

	public void placeObject(){
		try {
			transform.position = placeNum.transform.position;
		} catch (System.Exception ex) {
			returnToInit();
		}
	}

	void returnToInit(){
		transform.position = initPlace;
	}

	public void OnTriggerEnter2D(Collider2D other){
		Debug.Log("collide");
		placeNum = other.gameObject;
		Debug.Log ("taken " + (System.Convert.ToInt32 (other.name [3])-49));
		GameObject.Find ("EventSystem").GetComponent<checkWudhuAnswer> ().tookPlace ((System.Convert.ToInt32 (other.name [3])-49), int.Parse(gameObject.name));
	}

	void OnTriggerExit2D(Collider2D other){
		Debug.Log("exit");
		placeNum = null;
		GameObject.Find ("EventSystem").GetComponent<checkWudhuAnswer> ().releasePlace ((System.Convert.ToInt32 (other.name [3])-49));
	}

	// Update is called once per frame
	void Update () {

	}
}