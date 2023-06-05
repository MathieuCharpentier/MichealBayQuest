using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{


	public Main main;
    public Transform bloodPrefab;
    public Transform explodeParticle;

    float movementSpeed = 4.5f;

	public int life = 3;
    public int score = 0;





	
	void Update () 
	{	
		
		if(Input.GetButton("Right") && transform.position.x <= 3)
		{
			transform.Translate(movementSpeed*Time.deltaTime, 0, 0);
		}
		if(Input.GetButton("Left") && transform.position.x >= -3)
		{
			transform.Translate(-movementSpeed*Time.deltaTime, 0, 0);
		}
        if (Input.GetButton("Up") && transform.position.y <= 6)
        {
            transform.Translate(0, movementSpeed * Time.deltaTime, 0);
        }
        if (Input.GetButton("Down") && transform.position.y >= -6)
        {
            transform.Translate(0, -movementSpeed * Time.deltaTime, 0);
        }

        if (life <= 0)
		{
			main.EndGame();
			Destroy(gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
            Transform newExplosion = Instantiate(explodeParticle, transform.position, Quaternion.identity);
            Destroy(other.gameObject);		
			life -= 1;
			main.UpdateLifeHUD(life);
			
		}
        if (other.tag == "Objectif")
        {
            Transform newBlood = Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);          
            score += 1;            
            main.UpdateScoreHUD(score);
        }
        if (other.tag == "Police")
        {
            Transform newExplosion = Instantiate(explodeParticle, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            life -= 1;
            main.UpdateLifeHUD(life);
        }
        if (other.tag == "Ambulance")
        {
            Transform newExplosion = Instantiate(explodeParticle, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            life += 1;
            main.UpdateLifeHUD(life);
        }
    }

}

