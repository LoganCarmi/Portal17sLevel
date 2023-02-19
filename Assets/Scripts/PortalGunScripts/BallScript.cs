using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] float Force = 50f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * Force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) {
        
        if (other.collider.tag == "Ground" || other.collider.tag == "Wall") {
            Destroy(gameObject);
        }

    }

}
