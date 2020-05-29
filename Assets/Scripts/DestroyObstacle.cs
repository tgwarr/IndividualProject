using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
	private float outOfBoundsX = -100.0f;
   
    void Start()
    {
        
    }

    
    void Update()
    {
		if(transform.position.x <= outOfBoundsX)
		{
			Destroy(gameObject);
		}
    }

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
		}
	}
}
