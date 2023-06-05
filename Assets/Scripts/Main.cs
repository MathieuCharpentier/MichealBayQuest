using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Main : MonoBehaviour 
{

	/* PROPRIETES DU MAIN */

	// référence vers le prefab de l'Enemy, dont on va se servir pour Instantier tous les Enemy du jeu
	// la variable est en "public", on peut donc la régler dans l'editor
	public Transform enemyPrefab;
    public Transform voiturePrefab;
    public Transform AmbulancePrefab;
    public Transform objectifPrefab;
    public Transform LignPrefab;
    
    // champ texte du HUD qui affiche la valeur de vie du Player
    // la variable est en "public", on peut donc la régler dans l'editor
    public TextMeshPro lifeText;
    public TextMeshPro scoreText;
    public TextMeshPro scoreTextEnd;

    // référence vers le gameObject de l'écran de fin, que l'on va activer lorsque la partie se terminera
    // la variable est en "public", on peut donc la régler dans l'editor
    public GameObject endScreen;

	// référence vers le gameObject de l'écran de début, qu'on va désactiver lorsque la partie commencera 
	// la variable est en "public", on peut donc la régler dans l'editor
	public GameObject startScreen;
    public GameObject player;

	// la variable gameTimer va nous servir à tracker le temps qui passe pour pouvoir spawner les enemy
	float gameTimer;

	// on règle ici l'intervalle de temps entre les spawn des Enemy
	float spawnDelay = 1.5f;
    float ambulanceSpawn =25f;
    float ambulanceTimer;
    public float policeSpawn = 6f;
    float policeTimer;
	// bool qui indique si la partie est en cours ou si le joueur est sur un menu
	public bool isPlaying;



	/* FONCTIONS DU MAIN */

	// la fonction start est appellée automatiquement au début du jeu
	void Start () 
	{
		// on affiche l'écran start en activant le gameObject correspondant
		// SetActive() via code équivaut à cocher/décocher la box en haut à gauche de l'inspector d'un gameObject
		startScreen.SetActive(true);
	}

	// fonction qui lance la partie, appellée lorsque le joueur clique sur le bouton de l'écran start
	public void StartGame()
	{
		// on cache l'écran start en désactivant le gameObject correspondant
		startScreen.SetActive(false);
        player.SendMessage("StartGame");
		// on passe le bool isPlaying à true pour indiquer que la partie vient de commencer
		isPlaying = true;
	}

	// la fonction Update s'effectue automatiquement à chaque frame
	// l'Update du Main gère nottament le spawn des Enemy
	// à chaque frame, la variable gameTimer va s'incrémenter
	// lorque la valeur de gameTimer est supérieure ou égale à celle de spawnDelay, on Instantiate un Enemy
	void Update () 
	{
		// on execute le code de spawn des Enemy seulement si la partie a été lancée, c'set à dire si le bool isPlaying est true
		if(isPlaying)
		{
			// à chaque frame, on incrémente gameTimer pour représenter le temps qui passe
			// Time.deltatime représente le temps écoulé depuis la dernière frame
			gameTimer = gameTimer + Time.deltaTime;

            policeTimer += Time.deltaTime;
            ambulanceTimer += Time.deltaTime;

            if (policeTimer >= policeSpawn)
            {
                Transform newenemy = Instantiate(enemyPrefab).transform;
                float policePositionX = Random.Range(-2.5f, 2.5f);
                float policePositionY = -6f;
                newenemy.transform.position = new Vector3(policePositionX, policePositionY, 0);
                policeTimer = 0;
                if(policeSpawn > 1.6f)
                policeSpawn -= 0.2f;
            }
            if (ambulanceTimer >= ambulanceSpawn)
            {
                Transform newambulance = Instantiate(AmbulancePrefab).transform;
                float ambulancePositionX = Random.Range(-3f, 3f);
                float ambulancePositionY = 6f;
                newambulance.transform.position = new Vector3(ambulancePositionX, ambulancePositionY, 0);
                ambulanceTimer = 0;
                if(ambulanceSpawn > 7f)
                ambulanceSpawn -= 1f;
            }
			if(gameTimer >= spawnDelay)
			{
				
				Transform newCar = Instantiate(voiturePrefab).transform;
                
                float carPositionX = Random.Range(-2.5f, 2.5f); 
				float carPositionY = 6f;
                
				newCar.transform.position = new Vector3(carPositionX, carPositionY, 0);

                Transform newWalker = Instantiate(objectifPrefab).transform;

                float walkerPositionX = -2.5f;
                float walkerPositionY = Random.Range(0f, 6f);
                
                newWalker.transform.position = new Vector3(walkerPositionX, walkerPositionY, 0);

                Transform newLign = Instantiate(LignPrefab).transform;

                float lignPositionX = 0;
                float lignPositionY = 6;

                newLign.transform.position = new Vector3(lignPositionX, lignPositionY, 0);

                gameTimer = 0;
                spawnDelay -= 0.00005f;

            }
		}
        
    }
        
		
// la fonction UpdateLifeHUD permet de changer l'affichage du champ texte représentant la vie sur le HUD

public void UpdateLifeHUD(int newLifeValue)
	{
		// pour convertir un int (newLifeValue) en string et l'afficher en texte, on utilise l'opération "" + int
		lifeText.text = "" + newLifeValue;
	}
 public void UpdateScoreHUD(int newScoreValue)
    {
        // pour convertir un int (newLifeValue) en string et l'afficher en texte, on utilise l'opération "" + int
        scoreText.text = "" + newScoreValue;
    }

    public void EndGame()
	{
		// on passe le bool isPlaying à false pour signaler que la partie est terminée et stopper le spawn des Enemy
		isPlaying = false;
        scoreTextEnd.text = scoreText.text;
        player.SendMessage("EndGame");
        endScreen.SetActive(true);
	}


}
