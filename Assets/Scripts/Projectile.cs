using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Main main;
    public Transform explodeParticle;
    // Use this for initialization
    void Start () {
        main = FindObjectOfType<Main>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -2 * Time.deltaTime, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Police")
        {
            Transform newExplosion = Instantiate(explodeParticle, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<Player>().score += 2;
            main.UpdateScoreHUD(GameObject.Find("Player").GetComponent<Player>().score);
        }
        if (other.tag == "Enemy")
        {
            Transform newExplosion = Instantiate(explodeParticle, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<Player>().score += 1;
            main.UpdateScoreHUD(GameObject.Find("Player").GetComponent<Player>().score);
        }
        if (other.tag == "Ambulance")
        {
            Transform newExplosion = Instantiate(explodeParticle, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<Player>().life += 1;
            main.UpdateLifeHUD(GameObject.Find("Player").GetComponent<Player>().life);
        }
    }
}

