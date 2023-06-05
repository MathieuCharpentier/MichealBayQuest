using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour {
	public AudioSource source;
	public AudioClip explosion1;
	public AudioClip explosion2;
	public AudioClip explosion3;
	int explChoose;
	
	void Start()
	{
		explChoose = Random.Range(1,3);
		if(explChoose == 1)
		{
			source.clip = explosion1;
		}

		if(explChoose == 2)
		{
			source.clip = explosion2;
		}

		if(explChoose == 3)
		{
			source.clip = explosion3;
		}

		source.Play();
	}
}
