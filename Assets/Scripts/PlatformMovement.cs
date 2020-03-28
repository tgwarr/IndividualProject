using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
	public int speed;
	public GameObject[] platforms;
    // Start is called before the first frame update
    void Start()
    {
		platforms = GameObject.FindGameObjectsWithTag("platform");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
