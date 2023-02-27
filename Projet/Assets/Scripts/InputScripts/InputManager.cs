using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


// Script qui gère la manière à laquelle les inputs sont gérés
public class InputManager : MonoBehaviour
{
    // Déclaration des variables
    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    [SerializeField] GunScript gunScript;

    PlayerControls controls;
    PlayerControls.PlayerActions playerControls;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    // Définition des fonctions et association à quelle fonction correspond quel input
    private void Awake() {
        
        // Récupération de mon controlleur d'input
        controls = new PlayerControls();
        playerControls = controls.Player;

        // Association des inputs du controlleurs à leurs fonctions en récupérant les valeurs des inputs si nécessaire
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
    
    // Récupère de manière continue les déplacements du joueur et de sa caméra
    private void Update() {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
    }
}
