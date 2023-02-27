using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Script lié aux portails
public class Portal : MonoBehaviour
{
    // Déclaration de la variable nécessaire
    string OtherPortalTag;

    // Initialisation de la variable dès sa création
    private void Start() {
        if(gameObject.CompareTag("OrangePortal")) OtherPortalTag = "BluePortal";
        else OtherPortalTag = "OrangePortal";
    }

    // Lorsqu'un objet passe au travers
    void OnTriggerEnter(Collider other) {
        
        // Si l'objet qui passe au travers possède le tag "Player" et que l'autre portail existe bien
        if (other.CompareTag("Player") && GameObject.FindWithTag(OtherPortalTag) != null) {

            // Désactivation du CharacterController pour permettre la téléportation
            other.GetComponent<CharacterController>().enabled = false;

            // Calcul de la nouvelle position du joueur
            Vector3 new_position = GameObject.FindWithTag(OtherPortalTag).transform.position + 2 * GameObject.FindWithTag(OtherPortalTag).transform.right;

            // Calcul de la nouvelle rotation du joueur
            other.transform.rotation = Quaternion.Euler(GameObject.FindWithTag(OtherPortalTag).transform.rotation.eulerAngles + new Vector3(0, 90, 0));

            // Téléporte le joueur
            other.gameObject.transform.position = new_position;
            
            // Réactivation du CharacterController pour permettre les déplacements à nouveau du joueur
            other.GetComponent<CharacterController>().enabled = true;
        
        // Si l'objet qui passe au travers possède le tag "MovableItem" et que l'autre portail existe bien
        } else if (other.CompareTag("MovableItem") && GameObject.FindWithTag(OtherPortalTag) != null) {
            
            // Calcul de la position de l'objet
            Vector3 new_position = GameObject.FindWithTag(OtherPortalTag).transform.position + 2 * GameObject.FindWithTag(OtherPortalTag).transform.right;
            
            // Téléporte l'objet
            other.gameObject.transform.position = new_position;
        
        }

    }

}
