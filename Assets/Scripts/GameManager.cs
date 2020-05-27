using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject titleScreen;
	public TextMeshProUGUI gameOverText;
	public Button restartButton;
	public bool isGameRunning;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

	public void StartGame()
	{
		titleScreen.gameObject.SetActive(false);
		isGameRunning = true;
	}

	public void GameOver()
	{
		gameOverText.gameObject.SetActive(true);
		restartButton.gameObject.SetActive(true);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
