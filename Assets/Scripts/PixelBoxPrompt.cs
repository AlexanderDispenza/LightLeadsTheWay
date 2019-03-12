using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelBoxPrompt : MonoBehaviour {

    bool isEnabled; 
	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        isEnabled = false;
    }
	
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Inside Trigger");
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            isEnabled = true;
        }
        else if (isEnabled == true && collision.gameObject.CompareTag("Player") == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }

    }

   
}
