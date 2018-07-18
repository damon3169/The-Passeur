using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{

	float speed = 40f;
	float vectircalSpeed = 0f;
	float minusVectircalSpeed = 2f;
	GameObject playerSpotLight;
	GameObject playerPointLight;
	private bool isGameOver = false;
	private int slaves = 3;
	private bool isCrashing = false;
	private float crashTimer;
	[SerializeField]
	private float crashDuration;

	// Use this for initialization
	void Start()
	{
		playerSpotLight = GameObject.Find("playerSpotLight");
		playerPointLight = GameObject.Find("playerPointLight");
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(new Vector3(1, 0, 0) * vectircalSpeed * Time.deltaTime);
		if (isCrashing == true)
		{
			Debug.Log("test");

			if (Time.time - crashTimer < crashDuration)
			{
				vectircalSpeed = -2;
			}
			else
			{
				isCrashing = false;
				vectircalSpeed = 0;
				speed = 40f;
			}
		}
		else
		{
			if (Input.GetKey("w") && vectircalSpeed <= 7)
			{
				vectircalSpeed += 0.05f;
			}

			if (Input.GetKey("s") && vectircalSpeed >= 0.05f)
			{
				vectircalSpeed -= 0.025f;
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

		if (slaves == 0)
		{
			isGameOver = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{


		if (other.tag == "obstacle" && this.tag == "Player")
		{

			looseOneSlave();
			crashTimer = Time.time;
			vectircalSpeed = 0;
			speed = 0;
			isCrashing = true;
		}

		if (other.tag == "enemy")
		{
			isGameOver = true;
		}
	}

	private void looseOneSlave()
	{
		slaves -= 1;
	}

	public bool isItOver()
	{
		return isGameOver;
	}
}
