using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelBoxPrompt : MonoBehaviour {

   [SerializeField] private GameObject tileBox;


	// Use this for initialization
	void Start ()
    {
        tileBox.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            tileBox.SetActive(true);
            Debug.Log("Inside Trigger");
        }
        else tileBox.SetActive(false);

    }

   
}
