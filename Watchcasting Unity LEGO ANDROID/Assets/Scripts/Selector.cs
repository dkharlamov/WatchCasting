using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

	GameObject selected_object;

	// Use this for initialization
	void Start () {
		selected_object = new GameObject();
	}

//	void OnCollisionEnter (Collision col)
//	{
//		TextMesh debug2 = GameObject.Find("Debug2").GetComponent<TextMesh>();
//		debug2.text = col.gameObject.name;
//	}
	
	// Update is called once per frame



	void Update () {

		int state = WatchRotation.mouseState;

		TextMesh debug2 = GameObject.Find("Debug2").GetComponent<TextMesh>();
		Ray casted = new Ray(this.transform.position, this.transform.up);
		Debug.DrawRay(this.transform.position, this.transform.up);
		RaycastHit hit_info = new RaycastHit();
		if(Physics.Raycast(casted, out hit_info))
		{
			if(hit_info.collider.tag == "Collidable" && state == 1){
				selected_object = hit_info.collider.gameObject;
			}
			debug2.text = hit_info.collider.name + "\n" + state;
		}else{
			debug2.text = "----" + "\n" + state;
		}

		if(state == 0)
		{
			selected_object = new GameObject();
		}
		else
		{
			selected_object.transform.localRotation = this.transform.rotation;
		}
	}
}
