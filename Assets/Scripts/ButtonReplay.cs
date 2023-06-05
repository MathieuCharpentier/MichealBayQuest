using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonReplay : MonoBehaviour 
{

	void OnMouseDown()
	{
		SceneManager.LoadScene("Game");
	}
}
