using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    [SerializeField] GunScript gunScript;

    PlayerControls controls;
    PlayerControls.PlayerActions playerControls;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    private void Awake() {
        controls = new PlayerControls();
        playerControls = controls.Player;
        playerControls.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        playerControls.Jump.performed += _ => movement.OnJumpPressed();

        playerControls.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();    
        playerControls.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

        playerControls.ShootLeft.performed += _ => gunScript.Shoot("Left");
        playerControls.ShootRight.performed += _ => gunScript.Shoot("Right");
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
