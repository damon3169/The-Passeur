using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

	protected gameController gameManager;
	private Vector3 collidePosition;
	// Use this for initialization
	void Awake () {
		GameObject manager = GameObject.Find("GameManager");
		gameManager = manager.GetComponent<gameController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "playerLight" || other.tag == "Player")
		{
			collidePosition = this.transform.position;
		}
	}

	public virtual void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "playerLight" || other.tag == "Player")
		{
			gameManager.isAlarm = true;
		}
	}

	public virtual void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "playerLight" || other.tag == "Player")
		{
			gameManager.isAlarm = false;
		}
	}
}
