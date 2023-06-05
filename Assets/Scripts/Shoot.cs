using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject Bomb;
    public GameObject Missile;
    float Timer;
    float Timer2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        Timer2 += Time.deltaTime;
        if (Input.GetButtonDown("Bomb") && Timer >= 0.9f )
        {
            Instantiate
                (
                Bomb,
                transform.position,
                Quaternion.identity
                );
            Timer = 0;
        }
        if (Input.GetButtonDown("Missile") && Timer2 >= 1f)
        {
            Instantiate
                (
                Missile,
                transform.position,
                Quaternion.identity
                );
            Timer2 = 0;
        }
    }
}
