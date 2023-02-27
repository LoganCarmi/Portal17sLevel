using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script lié au mouvement de la caméra lors du déplacement de la souris
public class MouseLook : MonoBehaviour {

    // Déclaration des variables
    [SerializeField] float xSensitivity = 8f;
    [SerializeField] float ySensitivity = 0.5f;
    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;

    float xRotation = 0f;
    float mouseX, mouseY;

    // Setup du curseur verrouillé et invisible
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    // Rotation de la caméra en fonction du déplacement de la souris
    private void Update() {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }

    // Réception des déplacements de la souris
    public void ReceiveInput (Vector2 mouseInput) {
        
        mouseX = mouseInput.x * xSensitivity;
        mouseY = mouseInput.y * ySensitivity;

    }
    
}
