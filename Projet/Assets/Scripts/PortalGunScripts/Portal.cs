using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    string OtherPortalTag;

    private void Start() {
        if(gameObject.CompareTag("OrangePortal")) OtherPortalTag = "BluePortal";
        else OtherPortalTag = "OrangePortal";
    }

    void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player") && GameObject.FindWithTag(OtherPortalTag) != null) {
            other.GetComponent<CharacterController>().enabled = false;
            // Calculer la nouvelle position du joueur
            Vector3 new_position = GameObject.FindWithTag(OtherPortalTag).transform.position + 2 * GameObject.FindWithTag(OtherPortalTag).transform.right;


            other.transform.rotation = Quaternion.Euler(GameObject.FindWithTag(OtherPortalTag).transform.rotation.eulerAngles + new Vector3(0, 90, 0));

            // Téléporter le joueur
            other.gameObject.transform.position = new_position;
            other.GetComponent<CharacterController>().enabled = true;
        }
    }

}
