//
//	掉落道具
//
using UnityEngine;
using System.Collections;


public class DropItem : MonoBehaviour {

	public int ID {get; set;}			// uid
	public int OwnID {get; set;}		// own id


	// Use this for initialization
	void Start () {
	}

	void OnEnable() {
	}

	void OnDisable() {
	}

	void OnTriggerEnter(Collider collider)   { 
		Debug.Log("BreakableObject:OnTriggerEnter");

		string tag = collider.gameObject.tag;
		if (tag == "Player") {

		}
	}

	IEnumerator delayForDestroy(float time) {
		yield return new WaitForSeconds(time);

		Destroy(gameObject);
	}
}
