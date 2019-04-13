using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformer : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D rb2d;

	public float fallDelay;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			StartCoroutine(Fall());
		} 
	}

	IEnumerator Fall()
	{
		yield return new WaitForSeconds(fallDelay);
		rb2d.isKinematic = false;
		yield return 0;

	}

}
