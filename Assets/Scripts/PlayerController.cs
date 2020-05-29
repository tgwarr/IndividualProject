using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	public ParticleSystem explosion;
	public AudioClip explosion_01;
	public AudioClip hit_01;
	public AudioClip jump_01;
	private AudioSource audioSource;
	private Rigidbody playerRB;
	private Animator playerAnimator;
	public float moveSpeed;
	public float forceMultiplier;
	public bool onGround;
	public bool gameOver;
	public bool isAlive;
	public bool useGravity = true;
	private EventManager eventManager;


	void Start()
	{
		eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
		playerAnimator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		playerRB = GetComponent<Rigidbody>();
		onGround = true;
		gameOver = false;
		isAlive = true;
	}


	void Update()
	{
		Vector3 Movement = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		if (Input.GetKeyDown(KeyCode.Space) && onGround && isAlive)
		{
			Jump();
		}
		playerRB.transform.position += Movement * moveSpeed * Time.deltaTime;
	}

	void FixedUpdate()
	{
		playerRB.useGravity = false;
		if(useGravity)
		{
			playerRB.AddForce(Physics.gravity * (playerRB.mass * playerRB.mass));
		}
	}

	private void Jump()
	{
		playerRB.AddForce(Vector3.up * forceMultiplier, ForceMode.Impulse);
		onGround = false;
		audioSource.PlayOneShot(jump_01, 1.0f);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Obstacle") && isAlive && !gameOver)
		{
			playerAnimator.SetBool("PlayerDeath", true);
			explosion.Play();
			audioSource.PlayOneShot(explosion_01, 1.0f);
			isAlive = false;
			gameOver = true;
			GameOver();
		}
		else if(collision.gameObject.CompareTag("platform") && !gameOver)
		{
			onGround = true;
			audioSource.PlayOneShot(hit_01, 1.0f);
		}
		else if(collision.gameObject.CompareTag("movingplatform") && !gameOver)
		{
			onGround = true;
			audioSource.PlayOneShot(hit_01, 1.0f);
		}
		else if(collision.gameObject.CompareTag("endplatform") && !gameOver)
		{
			audioSource.PlayOneShot(hit_01, 1.0f);
			eventManager.youWinEvent?.Invoke();
		}
	}

	private void GameOver()
	{
		eventManager.gameOverEvent?.Invoke();
	}

}


