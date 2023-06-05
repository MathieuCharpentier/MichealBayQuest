using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : MonoBehaviour 
{
	public Main main;

	void Update()
	{
        if(GameObject.Find("Main").GetComponent<Main>().isPlaying == false && Input.GetKey(KeyCode.Mouse0))
        main.StartGame();
	}
}
