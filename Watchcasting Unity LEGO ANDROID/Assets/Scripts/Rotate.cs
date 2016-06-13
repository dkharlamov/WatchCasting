using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Quaternion rotation = WatchRotation.rotation; //Quaternion.Euler (-WatchRotation.rotation.eulerAngles.y,
			                     // WatchRotation.rotation.eulerAngles.x, -WatchRotation.rotation.eulerAngles.z);

		transform.rotation = rotation;
	
	}
/*	void OnGUI() {
		GUIStyle style = new GUIStyle();
		style.fontSize = 70;
		style.normal.textColor = Color.red;
		GUI.Label(new Rect(100, 100, 800,400), WatchRotation.rotation.eulerAngles.ToString(), style);
	}*/
}
