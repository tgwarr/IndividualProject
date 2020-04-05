using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
	private const float spawnPointX = 100;
	private const float yRange = 10;
	private const float spawnPointZ = 10;
	public GameObject[] Obstacles;
    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("SpawnObstacles", 3.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void SpawnObstacles()
	{
		int randomSpawn = Random.Range(0, Obstacles.Length);
		Instantiate(Obstacles[randomSpawn], new Vector3(spawnPointX, Random.Range(-yRange, yRange), spawnPointZ), Obstacles[randomSpawn].transform.rotation);
	}
}
