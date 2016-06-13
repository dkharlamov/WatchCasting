using UnityEngine;
using System.Collections;

public class MoveCursorOnRay : MonoBehaviour {
	float y_position = 0.5f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float z = GameObject.Find ("Watch").transform.localRotation.eulerAngles.z;
		if (z > 180f)
			z = z-360f;
		y_position = z / 270f;
		transform.localPosition = new Vector3 (transform.localPosition.x, -0.5f+y_position, transform.localPosition.z);

	
	}


/*	void OnGUI() {
		GUIStyle style = new GUIStyle();
		style.fontSize = 70;
		style.normal.textColor = Color.red;
		GUI.Label(new Rect(100, 200, 800,400), "y=" +y_position, style);
	}*/
}
