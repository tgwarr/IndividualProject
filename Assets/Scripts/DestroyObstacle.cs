﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
	private float outOfBoundsX = -100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(transform.position.x <= outOfBoundsX)
		{
			Destroy(gameObject);
		}
    }
}
