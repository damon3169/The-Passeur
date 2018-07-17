using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{

	[SerializeField]
	private GameObject player;
	[SerializeField]
	private GameObject canvas;
	public bool isAlarm = false;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (player.GetComponent<ShipControl>().isItOver() == true)
		{
			GameObject.Find("GameOverText").GetComponent<UnityEngine.UI.Text>().enabled = true;
			Time.timeScale = 0;
			//Disable scripts that still work while timescale is set to 0
		}
	}
}
