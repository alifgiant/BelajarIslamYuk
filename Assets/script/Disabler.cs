using UnityEngine;
using System.Collections;

public class Disabler : MonoBehaviour {

	public GameObject[] gm;

	// Use this for initialization
	void Start () {
		if (hijaiyahSpawner != null)
			hijaiyahSpawner.enabled = false;
		if (GameObject.Find ("modeCarrier").GetComponent<mode> ().isSolo) {
			Debug.Log("SoloMode");
			deleteObject ();
			if (hijaiyahSpawner!=null)
				hijaiyahSpawner.enabled = true;
		} 
	}

	public void deleteObject(){
		foreach (GameObject i in gm){
			Destroy(i);
		}
	}

	public void takeCard(){
		GameObject bar = GameObject.Find("selectedBar");
		foreach (returnSelected item in bar.GetComponentsInChildren<returnSelected>()) {
			dragObject obj = GameObject.Find(item.id.ToString()).GetComponent<dragObject>();
			obj.OnTriggerEnter2D(GameObject.Find("num"+(System.Convert.ToInt32(item.id.ToString())+1)).collider2D);
			obj.placeObject();
		}
	}

	public PolygonCollider2D hipmiCollider;
	public Spawner hijaiyahSpawner;

	public void takeHuruf(){
		GameObject bar = GameObject.Find("selectedBar");
//		bool[] taken = new bool[29];
		GameObject generator = GameObject.Find("EventSystem");
		hipmiCollider.enabled = true;
		hijaiyahSpawner.enabled = true;

		foreach (returnSelected item in bar.GetComponentsInChildren<returnSelected>()) {
//			taken[item.id] = true;
			generator.GetComponent<hijaiyahGenerator> ().changeHuruf (item.id);
		}
	}
}
