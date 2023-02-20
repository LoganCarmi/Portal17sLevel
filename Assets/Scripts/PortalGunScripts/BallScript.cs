using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] float Force = 50f;
    [SerializeField] GameObject Portal;
    Rigidbody rb;
    Quaternion PortalRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * Force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) {
        
        if (other.collider.tag == "Ground" || other.collider.tag == "Wall") {

            if (other.collider.tag == "Wall") {
                Quaternion rotation = other.gameObject.transform.rotation;
                float angle90 = Quaternion.Angle(rotation, Quaternion.Euler(0, 90, 0));
                float angle270 = Quaternion.Angle(rotation, Quaternion.Euler(0, 270, 0));
                float angle0 = Quaternion.Angle(rotation, Quaternion.Euler(0, 360, 0));


                if (Mathf.Approximately(angle90, 0f)) PortalRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                else if (Mathf.Approximately(angle270, 0f)) PortalRotation = Quaternion.Euler(new Vector3(0, 270, 0));
                else if (Mathf.Approximately(angle0, 0f)) PortalRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                else PortalRotation = Quaternion.Euler(new Vector3(0, 360, 0));;
            } else {
                PortalRotation = Quaternion.Euler(new Vector3(0, 0, 90));
            }

            
            if ( GameObject.FindWithTag(Portal.tag) == null ) Instantiate(Portal, gameObject.transform.position, PortalRotation);
            else {
                Destroy(GameObject.FindWithTag(Portal.tag));
                Instantiate(Portal, gameObject.transform.position, PortalRotation);
            }
            Destroy(gameObject);
        }

    }

}
