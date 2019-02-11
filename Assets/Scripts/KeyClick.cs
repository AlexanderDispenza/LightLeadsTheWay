using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyClick : MonoBehaviour {

    [SerializeField] private Rigidbody2D rb2d;

    public bool hasKey;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0.0f;
        hasKey = false;
	}

    private void OnMouseDown()
    {
        rb2d.gravityScale = 1.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Picked up key");
            hasKey = true;
            Destroy(gameObject);
        }
    }

}
