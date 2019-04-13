using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public KeyClick key;

	public string sceneName;
	Scene scene;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		scene = SceneManager.GetActiveScene();
		sceneName = scene.name;
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.CompareTag("Player") && key.hasKey == true && sceneName == "SampleScene")
		{
			SceneManager.LoadScene("Area 2");

		}
		else if (collision.gameObject.CompareTag("Player") && key.hasKey == true && sceneName == "Area 2")
		{
			SceneManager.LoadScene("Area 3");

		}
		else if (collision.gameObject.CompareTag("Player") && key.hasKey == true && sceneName == "Area 3")
		{
			SceneManager.LoadScene("Area 4");
		}

    }

}
