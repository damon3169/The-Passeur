using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathBoat	 : MonoBehaviour {

	[SerializeField]
	BezierCurve bCurve;
	float percentage = 0.0f;
	Vector3 currentTarget;

	// Use this for initialization
	void Start () {
		//bCurve = transform.GetChild(2).GetComponent<BezierCurve>();
		currentTarget = bCurve.GetPointAt(percentage) - new Vector3(0, 0, 1.5f);
	}
	
	// Update is called once per frame
	public void followThePass() {

		if (Vector3.SqrMagnitude(transform.position - currentTarget) < 10)
		{
			if (percentage < 0.9f)
			{
				percentage += 0.1f;
				currentTarget = bCurve.GetPointAt(percentage) - new Vector3(0,0,-1.5f);
			}
			else
			{
				Debug.Log("test");
				percentage = 0.0f;
				currentTarget = bCurve.GetPointAt(percentage) - new Vector3(0, 0, -1.5f);
			}
		}

			Vector3 dirBoat = currentTarget - transform.position;
			float angleBoat = Mathf.Atan2(dirBoat.y, dirBoat.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angleBoat, Vector3.forward), Time.deltaTime * 5f);
			//transform.rotation = Quaternion.Euler(0f, 0f, angleBoat);
			transform.Translate(new Vector3(1, 0, 0) * 4f * Time.deltaTime);
	}
}
