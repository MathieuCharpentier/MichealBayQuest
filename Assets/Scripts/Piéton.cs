using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piéton : MonoBehaviour
{

    /* PROPRIETES DE L'ENEMY */

    // on règle ici la vitesse de déplacement du piéton
    float movementSpeed = 4f;



    /* FONCTIONS DE L'ENEMY */

    // la fonction Update s'effectue automatiquement à chaque frame
    void Update()
    {
        // de la même façon que dans le Player, on déplace l'Enemy à chaque frame
        // dans ce cas, l'Enemy se déplace du haut vers le bas, on change donc le paramètre y de transform.Translate(x, y ,z)
        transform.Translate(2 * Time.deltaTime, -movementSpeed * Time.deltaTime, 0);
    }
}
