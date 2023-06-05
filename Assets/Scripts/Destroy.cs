using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        // le Player est rentré en collision avec quelque chose, mais on ne sait pas encore quoi
        // on check le tag de l'élément avec lequel le Player est rentré en collision 

        if (other.tag == "Enemy")
        {
            // si on est bien rentré en collision avec un Enemy, on détruit tout d'abord l'Enemy en question
            Destroy(other.gameObject);
        }
        if (other.tag == "Objectif")
        {
            
            Destroy(other.gameObject);
        }
        if (other.tag == "Police")
        {

            Destroy(other.gameObject);
        }
        if (other.tag == "Visu")
        {

            Destroy(other.gameObject);
        }
    }
}            
