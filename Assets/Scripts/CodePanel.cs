using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{

	[SerializeField]
	Text codeText;
	[SerializeField]
	GameObject barrier;
	string codeTextValue = "";

	// Update is called once per frame
	void Update ()
	{
		codeText.text = codeTextValue;

		// disable barrier if player enters correct code 
		if (codeTextValue == "6375")
		{
			gameObject.SetActive(false);
			barrier.gameObject.SetActive(false);
		}

		if (codeTextValue.Length >= 4)
		{
			codeTextValue = "";
		}
	}

	public void AddDigit(string digit)
	{
		codeTextValue += digit;
	}

}
