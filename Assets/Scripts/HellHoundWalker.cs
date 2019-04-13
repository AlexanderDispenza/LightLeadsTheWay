﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHoundWalker : MonoBehaviour
{

	// Makes a private reference to Rigidbody2D Component
	Rigidbody2D rb;

	// Variable to control speed of GameObject
	public float speed;

	// Used when flipping character
	public bool isFacingRight;

	public int health;

	// Use this for initialization
	void Start()
	{

		// Assigning 'tags' through script
		tag = "Enemy";

		// Used to get and save a reference to the Rigidbody2D Component
		rb = GetComponent<Rigidbody2D>();

		// Change variables of Rigidbody2D after saving a reference
		rb.mass = 1.0f;
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		rb.sleepMode = RigidbodySleepMode2D.NeverSleep;

		// Check if speed variable was set in the inspector
		if (speed <= 0 || speed > 5.0f)
		{
			// Assign a default value if one was not set
			speed = 5.0f;

			// Prints a warning message to the Console
			// - Open Console by going to Window-->Console (or Ctrl+Shift+C)
			Debug.LogWarning("Speed not set on " + name + ". Defaulting to " + speed);
		}

		// Check if health variable was set in the inspector
		if (health <= 0 || health > 5)
		{
			// Assign a default value if one was not set
			health = 5;

			// Prints a warning message to the Console
			// - Open Console by going to Window-->Console (or Ctrl+Shift+C)
			Debug.LogWarning("Health not set on " + name + ". Defaulting to " + health);
		}
	
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void FixedUpdate()
	{
		// Make sure Rigidbody2D is attached before doing stuff
		if (rb)
			if (!isFacingRight)
				// Make player move left 
				rb.velocity = new Vector2(-speed, rb.velocity.y);
			else
				// Make player move right 
				rb.velocity = new Vector2(speed, rb.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("EnemyBlocker"))
		{
			flip();
		}
	}

	void flip()
	{
		// Toggle variable
		isFacingRight = !isFacingRight;

		// Keep a copy of 'localScale' because scale cannot be changed directly
		Vector3 scaleFactor = transform.localScale;

		// Change sign of scale in 'x'
		scaleFactor.x *= -1; // or - -scaleFactor.x

		// Assign updated value back to 'localScale'
		transform.localScale = scaleFactor;
	}

	void die()
	{
		Destroy(gameObject);
	}
}