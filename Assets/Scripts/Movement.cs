using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{

	/* PROPRIETES DE L'ENEMY */

	// on règle ici la vitesse de déplacement de l'Enemy
	public float movementSpeed;



	/* FONCTIONS DE L'ENEMY */

	// la fonction Update s'effectue automatiquement à chaque frame
	void Update () 
	{
		// de la même façon que dans le Player, on déplace l'Enemy à chaque frame
		// dans ce cas, l'Enemy se déplace du haut vers le bas, on change donc le paramètre y de transform.Translate(x, y ,z)
		transform.Translate(0, -movementSpeed*Time.deltaTime, 0);
        movementSpeed += 0.01f;
	}
}
