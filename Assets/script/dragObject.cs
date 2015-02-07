using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Hit;

public class dragObject : MonoBehaviour {

	private float dist;
	private Transform toDrag;

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
		checkAnswer(placeNum);
	}	

	void OnDisable(){
		Debug.Log("Disabled");
		GetComponent<ReleaseGesture>().Released -= HandleReleased;
	}

	void checkAnswer(GameObject place){
		try {
			transform.position = placeNum.transform.position;
		} catch (System.Exception ex) {
			Debug.Log(ex);
			transform.position = initPlace;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("collide");
		placeNum = other.gameObject;
	}

	void OnTriggerExit2D(Collider2D other){
		Debug.Log("exit");
		placeNum = null;
	}

	// Update is called once per frame
	void Update () {
//		//android platform
//		if(platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer){
//			if (Input.GetKeyDown(KeyCode.Escape)) {
//				Application.Quit(); 
//			}
//			
//			if(Input.touchCount > 0) {
//				if(Input.GetTouch(0).phase == TouchPhase.Began){
//					checkTouch(Input.GetTouch(0).position);
//				}
//				if(Input.GetTouch(0).phase == TouchPhase.Moved){
//					if (dragging) {
//						checkDrag(Input.GetTouch(0).position);
//					}
//				}
//				if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) {					
//					dragging = false;			
//				}
//			}
//		}else{
//			//If running game in editor
//			//#if UNITY_EDITOR
//			//If mouse button 0 is down
//			if (Input.GetMouseButton (0)) {
//				//Cache mouse position
//				/*Vector2 mouseCache = Input.mousePosition; 
//				 * touched = true;*/
//				if (Input.GetMouseButtonDown (0)) {
//					checkTouch(Input.mousePosition);
//				}
//				if (Input.GetMouseButton (0)) {
//					if (dragging) {
//						//Debug.Log("drag");
//						checkDrag(Input.mousePosition);						
//					}
//				}
//			}
//			if (Input.GetMouseButtonUp (0)) {					
//				dragging = false;			
//			}
//			//Debug.LogError(dragging);
//		}
//		//#endif
	}

//	void checkTouch(Vector2 pos){
//		RaycastHit hit;
//		Vector3 v3;
//		Ray ray = Camera.main.ScreenPointToRay(pos); 
//		if(Physics.Raycast(ray,out hit))
//		{
//			if(hit.transform.tag.Equals("Player"))
//			{
//				//Debug.Log("tes clickked");
//				toDrag = hit.transform;
//				dist = hit.transform.position.z - Camera.main.transform.position.z;
//				v3 = new Vector3(pos.x, pos.y, dist);
//				v3 = Camera.main.ScreenToWorldPoint(v3);
//				offset = toDrag.position - v3;
//				dragging = true;
//			}
//		}
//	}
//	
//	void checkDrag(Vector2 pos){
//		v3 = new Vector3 (pos.x, pos.y, dist);
//		v3 = Camera.main.ScreenToWorldPoint (v3);
//		toDrag.position = v3 + offset;
//		//Debug.Log("drag");
//	}
}
