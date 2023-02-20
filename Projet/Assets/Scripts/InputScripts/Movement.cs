using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #pragma warning disable 649

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

    private void Update() {

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        if(isJumping) {
            if(isGrounded) {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            isJumping = false;
        }

        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void ReceiveInput(Vector2 _horizontalInput) {
        horizontalInput = _horizontalInput;
    }

    public void OnJumpPressed () {
        isJumping = true;
    }
}
