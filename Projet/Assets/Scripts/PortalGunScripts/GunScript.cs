using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script lié au Gun
public class GunScript : MonoBehaviour
{

    // Déclaration des variables
    [SerializeField] GameObject BallSpawnPoint;
    [SerializeField] GameObject OrangeBall;
    [SerializeField] GameObject BlueBall;

    // Shoot en fonction du clic effectué
    public void Shoot (string side) {

        if (side == "Right") Instantiate(BlueBall, BallSpawnPoint.transform.position, BallSpawnPoint.transform.rotation); 
        else Instantiate(OrangeBall, BallSpawnPoint.transform.position, BallSpawnPoint.transform.rotation);
        
    }
}
