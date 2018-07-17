using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<ShipControl>().isItOver() == true)
		{
			Time.timeScale = 0;
			//Disable scripts that still work while timescale is set to 0
		}
	}
}
