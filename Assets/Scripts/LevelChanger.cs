using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChanger : MonoBehaviour {

    public KeyClick key;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && key.hasKey == true)
        {
            SceneManager.LoadScene("area 2");
        }
    }

}
