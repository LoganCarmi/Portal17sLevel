using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Script du Shooter de la balle d'énergie
public class ShooterScript : MonoBehaviour
{
    // Déclaration des variables
    [SerializeField] GameObject BallSpawnPoint;
    [SerializeField] GameObject Ball;
    int count;

    // Initialisation du count lors du démarrage à 0
    private void Start() {
        count = 0;
    }

    // Appel de la fonction d'Update avec un nombre d'appel précis, à savoir 5/s
    private void FixedUpdate() {

        // Si le compteur est à 0, il crée la boule d'énergie à la position donnée en variable
        // Lorsque les 12s sont passées, on reset le compteur et on permet la création d'une nouvelle boule d'énergie 
        if (count == 0) {
            Instantiate(Ball, BallSpawnPoint.transform.position, BallSpawnPoint.transform.rotation);
        } else if (count >= 600) {
            count = -1; 
        }
        count++;
    }


}
