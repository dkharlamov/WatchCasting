using UnityEngine;
using System.Collections;
using System;

public class CursorInteraction : MonoBehaviour {
	float dwell = 0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider c) {
		/*if (WatchRotation.mouseState == 1) {
			transform.parent.position = c.transform.position; 
		}
		Debug.Log ("MOUSESTATE"+WatchRotation.mouseState);*/
		dwell += Time.deltaTime;
		//Debug.Log (dwell);
		if (dwell > 0.5f && dwell < 4f) {

			transform.parent.position= c.transform.position; 
			//c.collider.gameObject.GetComponent<Rigidbody> ().useGravity = false;
			//Debug.Log("dragging");
		}

		if (dwell >= 5f)
			dwell = 0;

	}
}
