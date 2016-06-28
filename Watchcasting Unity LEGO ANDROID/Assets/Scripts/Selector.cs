using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

	GameObject selected_object;
	//float y_position = 1.0f;

	// Use this for initialization
	void Start () {
		selected_object = new GameObject();
	}

	void OnCollisionEnter (Collision col)
	{
		int state = WatchRotation.mouseState;
		if(col.collider.tag == "Collidable" && state == 1)
		{
			selected_object = col.collider.gameObject;
		}

		if(state == 0)
		{
			selected_object = new GameObject();
		}
		else
		{
			selected_object.transform.position = this.transform.position;
		}

		
	}


	
	// Update is called once per frame
	void Update () {
//		float z = GameObject.Find ("Watch").transform.localRotation.eulerAngles.z;
//		if (z > 180f)
//		{
//			z = z-360f;
//		}
//		y_position = z / 270f;
//		transform.localPosition = new Vector3 (transform.localPosition.x, -0.5f+y_position, transform.localPosition.z);
	}
}
