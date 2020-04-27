using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public float gravityMultiplier;
	public bool onGround = true;
	public bool gameOver = false;
	// Start is called before the first frame update
	void Start()
	{
		playerAnimator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		playerRB= GetComponent<Rigidbody>();
		Physics.gravity *= gravityMultiplier;
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 Movement = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		if (Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
		{
			playerRB.AddForce(Vector3.up * forceMultiplier, ForceMode.Impulse);
			onGround = false;
			audioSource.PlayOneShot(jump_01, 1.0f);
		}
		playerRB.transform.position += Movement * moveSpeed * Time.deltaTime;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Obstacle"))
		{
			playerAnimator.SetBool("PlayerDeath", true);
			explosion.Play();
			audioSource.PlayOneShot(explosion_01, 1.0f);
			gameOver = true;
			Debug.Log("Game Over!");
		}
		else if(collision.gameObject.CompareTag("platform") && !gameOver)
		{
			onGround = true;
			audioSource.PlayOneShot(hit_01, 1.0f);
		}
	}
}


