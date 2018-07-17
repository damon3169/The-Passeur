using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBoatController : enemyController
{
	GameObject player;
	GameObject enemySpot;
	// Use this for initialization
	void Awake () {
		GameObject manager = GameObject.Find("GameManager");
		gameManager = manager.GetComponent<gameController>();
		player = GameObject.Find("playerBoat");
		enemySpot = transform.GetChild(1).gameObject;
		Debug.Log(enemySpot);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (gameManager.isAlarm)
		{
			Vector3 dir = player.transform.position - enemySpot.transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			enemySpot.transform.rotation = Quaternion.Slerp(enemySpot.transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * 8);
			Vector3 dirBoat = player.transform.position - transform.position;
			float angleBoat = Mathf.Atan2(dirBoat.y, dirBoat.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angleBoat, Vector3.forward), Time.deltaTime * 4);
			transform.Translate(new Vector3(1, 0, 0) * 4f * Time.deltaTime);
		}
	}
}
