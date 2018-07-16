using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtMouse : MonoBehaviour {

	Vector3 mouse_pos;
	Transform target ; //Assign to the object you want to rotate
	Vector3 object_pos ;
	float angle;
	// Use this for initialization
	public float RotationSpeed = 5;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		var pos = Camera.main.WorldToScreenPoint(transform.position);
		var dir = Input.mousePosition - pos;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
