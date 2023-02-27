using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



// Script équipé sur la boule d'énergie
public class EnergyBallScript : MonoBehaviour
{
    // Déclaration des variables
    [SerializeField] float Force = 50f;
    int BounceCount;
    Rigidbody rb;

    // Setup des variables avec leurs valeurs par défaut
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Ajout d'une force dès le spawn de la balle, pour permettre son mouvement dès sa création
        rb.AddForce(transform.forward * Force, ForceMode.Impulse);

        BounceCount = 0;
    }

    // Lorsque la balle entre en collision avec un autre objet
    void OnCollisionEnter(Collision collision)
    {
        // Check de si l'objet avec lequel il entre en collision possède le tag "Ground" ou "Wall"
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall")
        {
            // Incrémentation du compteur de rebond
            BounceCount++;

            // S'il y a eu un rebond contre un mur, il va prendre une force inverse à celle de son vecteur forward
            // A terme, ça devait servir à modifier le vecteur forward à chaque rebond.
            if(BounceCount % 2 == 1) {
                rb.AddForce(-transform.forward * Force, ForceMode.Impulse);
            } else {
                rb.AddForce(transform.forward * Force, ForceMode.Impulse);
            }

            // Si le nombre de rebond dépasse 5 ou équivaut à 5, on détruit l'objet
            if (BounceCount >= 5)
            {
                Destroy(gameObject);
            }
        
        // Si la balle entre en collision avec le joueur, cela a pour effet de le tuer, donc un reload de la Scene
        } else if (collision.gameObject.tag == "Player") {
            SceneManager.LoadScene("MainScene");
        }
    }
}
