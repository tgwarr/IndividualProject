using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformCollision : MonoBehaviour
{
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "movingplatform")
		{
			gameObject.transform.parent = other.gameObject.transform;
		}
	}

	void OnCollisionExit(Collision other)
	{
		gameObject.transform.parent = null;
	}
}
