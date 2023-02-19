using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] GameObject BallSpawnPoint;
    [SerializeField] GameObject OrangeBall;
    [SerializeField] GameObject BlueBall;

    public void Shoot (string side) {

        if (side == "Right") Instantiate(BlueBall, BallSpawnPoint.transform.position, BallSpawnPoint.transform.rotation); 
        else Instantiate(OrangeBall, BallSpawnPoint.transform.position, BallSpawnPoint.transform.rotation);
        
    }
}
