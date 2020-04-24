using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
	private Rigidbody playerRB;
	public float moveSpeed;
	public float forceMultiplier;
	public float gravityMultiplier;
	public bool onGround = true;
	public bool gameOver = false;
	// Start is called before the first frame update
	void Start()
	{
		playerRB= GetComponent<Rigidbody>();
		Physics.gravity *= gravityMultiplier;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
		{
			playerRB.AddForce(Vector3.up * forceMultiplier, ForceMode.Impulse);
			onGround = false;
		}
			
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Obstacle"))
		{
			gameOver = true;
			Debug.Log("Game Over!");
		}
		else if(collision.gameObject.CompareTag("platform") && !gameOver)
		{
			onGround = true;
		}
	}

	private void Move()
	{
		Vector3 Movement = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		playerRB.transform.position += Movement * moveSpeed * Time.deltaTime;
	}
}
