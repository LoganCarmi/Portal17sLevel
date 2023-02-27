using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script de la balle de création de portails
public class BallScript : MonoBehaviour
{

    // Déclaration des variables
    [SerializeField] float Force = 50f;
    [SerializeField] GameObject Portal;
    Rigidbody rb;
    Quaternion PortalRotation;

    // Initialisation des variables
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Déplacement constant lors de sa création
        rb.AddForce(transform.forward * Force, ForceMode.Impulse);
    }

    // Lorsqu'il entre en collision avec un objet, déclenche l'évènement suivant
    private void OnCollisionEnter(Collision other) {

        // Si l'objet avec lequel il est entré en collision possède le tag "Ground" ou "Wall"
        if (other.collider.tag == "Ground" || other.collider.tag == "Wall") {

            // Si c'est un mur, je lui donne une rotation en fonction de celle du mur auquel il est entré en collision
            // Le but ici est de faire en sorte que le portail puisse être orienté de la bonne manière 
            if (other.collider.tag == "Wall") {

                // Déclaration des angles avec lesquels il va effectué les vérifications
                Quaternion rotation = other.gameObject.transform.rotation;
                float angle90 = Quaternion.Angle(rotation, Quaternion.Euler(0, 90, 0));
                float angle270 = Quaternion.Angle(rotation, Quaternion.Euler(0, 270, 0));
                float angle0 = Quaternion.Angle(rotation, Quaternion.Euler(0, 360, 0));

                // Set de la variable de rotation du portail que la balle va créer    
                if (Mathf.Approximately(angle90, 0f)) PortalRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                else if (Mathf.Approximately(angle270, 0f)) PortalRotation = Quaternion.Euler(new Vector3(0, 270, 0));
                else if (Mathf.Approximately(angle0, 0f)) PortalRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                else PortalRotation = Quaternion.Euler(new Vector3(0, 360, 0));;
            } else {
                PortalRotation = Quaternion.Euler(new Vector3(0, 0, 90));
            }

            // Si le portail existe déjà, il remplace le précédent, autrement il se crée
            if ( GameObject.FindWithTag(Portal.tag) == null ) Instantiate(Portal, gameObject.transform.position, PortalRotation);
            else {
                Destroy(GameObject.FindWithTag(Portal.tag));
                Instantiate(Portal, gameObject.transform.position, PortalRotation);
            }
            Destroy(gameObject);
        }

    }

}
