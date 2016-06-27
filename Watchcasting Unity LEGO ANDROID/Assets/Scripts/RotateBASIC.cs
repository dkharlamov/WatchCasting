﻿using UnityEngine;
using System.Collections;
using System;

public class RotateBASIC : MonoBehaviour {


	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {


		Quaternion rotation = WatchRotation.rotation;  //Quaternion.Euler (-WatchRotation.rotation.eulerAngles.y,
		// WatchRotation.rotation.eulerAngles.x, -WatchRotation.rotation.eulerAngles.z);

		Quaternion one_eighty = Quaternion.AngleAxis(180, Vector3.up);
		Quaternion upside_down = Quaternion.AngleAxis(180, Vector3.right);

		transform.localRotation = rotation * one_eighty * upside_down;

		TextMesh debug = GameObject.Find("Debug").GetComponent<TextMesh>(); 

		debug.text = string.Format("Watch:\n{0}\n{1}\n{2}", transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);


	}
		


}






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

/*
// SWAPS X AND Y FOR CAMERA FOR TRANSFORM
float x = cam_rotation.eulerAngles.x;
float y = cam_rotation.eulerAngles.y;
float z = cam_rotation.eulerAngles.z;

cam_rotation.eulerAngles.Set(y, x, 0);

rotation.eulerAngles.Set(rotation.eulerAngles.x, rotation.eulerAngles.y, 0);
*/