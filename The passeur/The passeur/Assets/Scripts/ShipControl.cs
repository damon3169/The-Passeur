using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour {

	float speed = 10f;
	float vectircalSpeed = 0.5f;
	float minusVectircalSpeed =2f;


	Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w"))
		{
			
			rigidbody.AddForce(transform.up * vectircalSpeed);
		}

		if (Input.GetKey("s"))
		{
			rigidbody.AddForce(-rigidbody.velocity.normalized * minusVectircalSpeed);
		}

		if (Input.GetKey("a"))
		{
			rigidbody.AddTorque(1 * speed * Time.deltaTime);
		}

		if (Input.GetKey("d"))
		{
			rigidbody.AddTorque(-1 * speed * Time.deltaTime);
		}

	}
}
