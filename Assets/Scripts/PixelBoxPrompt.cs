using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelBoxPrompt : MonoBehaviour {

    bool isEnabled;

	public KeyClick key;

	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
	
    private void OnTriggerStay2D(Collider2D collision)
    {
		if (collision.gameObject.CompareTag("Player") && key.hasKey == false)
		{
		
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}
		else if (collision.gameObject.CompareTag("Player") == false && key.hasKey == false)
		{
		
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
		else if (collision.gameObject.CompareTag("Player") && key.hasKey == true) 
		{
			
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
    }
}
