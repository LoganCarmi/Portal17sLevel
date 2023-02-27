using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Script dédié aux Mouvements de mon joueur
public class Movement : MonoBehaviour
{
    // Pragma nécessaire pour éviter le spam de warning
    #pragma warning disable 649


    // Déclaration des variables
    [SerializeField] CharacterController controller;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float speed = 11f;
    [SerializeField] float gravity = -30f;
    [SerializeField] float jumpHeight = 3.5f;
    [SerializeField] Transform groundCheck;

    Vector2 horizontalInput;
    Vector3 verticalVelocity = Vector3.zero;
    bool isGrounded;
    bool isJumping;

    // Appel continu pour le déplacement et la vérification de si le joueur touche le sol ou non
    private void Update() {

        // Défini si le joueur touche le sol ou non
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        if(isJumping) {

            // Est-ce que le joueur a appuyé sur le bouton de saut et touche le sol ?
            if(isGrounded) {

                // Saut
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            isJumping = false;
        }

        // Déplacement ZQSD
        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        // Déplacement lié au Jump
        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    // Reçois la valeur du déplacement actuel effectué
    public void ReceiveInput(Vector2 _horizontalInput) {
        horizontalInput = _horizontalInput;
    }

    // Lors de l'appui du bouton de jump, on défini qu'il est en train de sauter
    public void OnJumpPressed () {
        isJumping = true;
    }
}
