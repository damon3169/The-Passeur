using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour {

	float speed = 30f;
	float vectircalSpeed = 0f;
	float minusVectircalSpeed =2f;
	GameObject playerSpotLight;
	GameObject playerPointLight;
	Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		playerSpotLight = GameObject.Find("playerSpotLight");
		playerPointLight = GameObject.Find("playerPointLight");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, 1, 0) * vectircalSpeed * Time.deltaTime);
		if (Input.GetKey("w") && vectircalSpeed <= 5)
		{
			vectircalSpeed += 0.05f;
		}

		if (Input.GetKey("s") && vectircalSpeed >= 0.05f)
		{
			vectircalSpeed -= 0.05f;
		}

		if (Input.GetKey("a"))
		{
			transform.Rotate(0, 0, Input.GetAxis("Horizontal") * speed * Time.deltaTime);
		}

		if (Input.GetKey("d"))
		{
			transform.Rotate(0, 0, Input.GetAxis("Horizontal") * speed * Time.deltaTime);
		}
		if (Input.GetKeyDown("e"))
		{
			playerPointLight.GetComponent<lightControl>().onOff();
		}
		if (Input.GetMouseButtonDown(1))
		{
			playerSpotLight.GetComponent<lightControl>().onOff();
		}
	}
}
