using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour {
    public Transform target;
    float movementSpeed = 4f;
    Vector3 velocity;
    public Transform bloodPrefab;
    public Transform explodeParticle;
    public float smoothTime = 0.5f;
    //public Transform player;
    void Start () {
		
	}


    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            target.position,
            ref velocity,
            smoothTime
        );

    }

    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.tag == "Enemy")
        {
            Transform newExplosion = Instantiate(explodeParticle, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        if (other.tag == "Objectif")
        {
            Transform newBlood = Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
