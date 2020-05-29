using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private const float spawnPointX = 100;
	private const float yRange = 5;
	private const float spawnPointZ = 10;
	private const float spawnPointZ2 = 30;
	private const float spawnPointZ3 = 50;
	public GameObject[] Obstacles;
	public GameObject titleScreen;
	public TextMeshProUGUI gameOverText;
	public TextMeshProUGUI youWinText;
	public Button restartButton;
	public Button winRestartButton;
	public bool isGameRunning;
	public bool titlePause = true;


    void Start()
    {
        
    }


    void Update()
    {
		if(titlePause == true)
		{
			Time.timeScale = 0f;
		}
		else 
		{
			Time.timeScale = 1.0f;
		}
    }
		

	public void StartGame()
	{
		titleScreen.gameObject.SetActive(false);
		isGameRunning = true;
		titlePause = false;
		InvokeRepeating("SpawnObstacles", 1.0f, 2.5f);
	}

	void SpawnObstacles()
	{
		if(isGameRunning)
		{	int randomSpawn = Random.Range(0, Obstacles.Length);
			Instantiate(Obstacles[randomSpawn], new Vector3(spawnPointX, Random.Range(-yRange, yRange), spawnPointZ), Obstacles[randomSpawn].transform.rotation);
			for(int rocketCount = 0; rocketCount < 2; rocketCount++)
		{
			Instantiate(Obstacles[randomSpawn], new Vector3(spawnPointX, Random.Range(-yRange, yRange), spawnPointZ2), Obstacles[randomSpawn].transform.rotation);
		}
			for(int rocketCount = 0; rocketCount < 3; rocketCount++)
		{
			Instantiate(Obstacles[randomSpawn], new Vector3(spawnPointX, Random.Range(-yRange, yRange), spawnPointZ3), Obstacles[randomSpawn].transform.rotation);
		}
		}
	}

	public void GameOver()
	{
		isGameRunning = false;
		gameOverText.gameObject.SetActive(true);
		restartButton.gameObject.SetActive(true);
	}

	public void YouWin()
	{
		isGameRunning = false;
		youWinText.gameObject.SetActive(true);
		winRestartButton.gameObject.SetActive(true);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
