using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformCollision : MonoBehaviour
{
	void OnTriggerStay(Collider collider)
	{
		collider.transform.parent = gameObject.transform;
	}

	void OnTriggerExit(Collider collider)
	{
		collider.transform.parent = null;
	}
}
