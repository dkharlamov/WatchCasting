using UnityEngine;
using System.Collections;
using System;

public class Rotate : MonoBehaviour {


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		
		Quaternion rotation = WatchRotation.rotation;  //Quaternion.Euler (-WatchRotation.rotation.eulerAngles.y,
			                     // WatchRotation.rotation.eulerAngles.x, -WatchRotation.rotation.eulerAngles.z);

		Quaternion cam_rotation = GameObject.Find("Camera").transform.rotation;

		/*


		TextMesh debug = GameObject.Find("Debug").GetComponent<TextMesh>();
		TextMesh debug2 = GameObject.Find("Debug2").GetComponent<TextMesh>();



		debug.text = string.Format("Watch:\n{0}\n{1}\n{2}", rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z);
		debug2.text = string.Format("Phone:\n{0}\n{1}\n{2}", cam_rotation.eulerAngles.x, cam_rotation.eulerAngles.y, cam_rotation.eulerAngles.z);
		*/


		/*				// SWAPS X AND Y FOR WATCH
		float x = rotation.eulerAngles.x;
		float y = rotation.eulerAngles.y;
		float z = rotation.eulerAngles.z;

		rotation.eulerAngles.Set(y, x, z);
		*/


		// SWAPS X AND Y FOR CAMERA FOR TRANSFORM
		float x = cam_rotation.eulerAngles.x;
		float y = cam_rotation.eulerAngles.y;
		float z = cam_rotation.eulerAngles.z;

		cam_rotation.eulerAngles.Set(y, x, 0);

		rotation.eulerAngles.Set(rotation.eulerAngles.x, rotation.eulerAngles.y, 0);


		transform.rotation = rotation * cam_rotation;


	
	}
/*	void OnGUI() {
		GUIStyle style = new GUIStyle();
		style.fontSize = 70;
		style.normal.textColor = Color.red;
		GUI.Label(new Rect(100, 100, 800,400), WatchRotation.rotation.eulerAngles.ToString(), style);
	}*/
}
