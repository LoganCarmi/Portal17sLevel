using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;

    PlayerControls controls;
    PlayerControls.PlayerActions playerMovement;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    private void Awake() {
        controls = new PlayerControls();
        playerMovement = controls.Player;
        playerMovement.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        playerMovement.Jump.performed += _ => movement.OnJumpPressed();

        playerMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();    
        playerMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDestroy() {
        controls.Disable();
    }
    
    private void Update() {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
    }
}
