﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformCollision : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		other.transform.parent = gameObject.transform;
	}

	void OnTriggerExit(Collider other)
	{
		other.transform.parent = null;
	}
}
