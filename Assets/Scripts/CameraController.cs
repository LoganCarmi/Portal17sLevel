using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float XSensitivity;
    public float YSensitivity;

    Transform orientation;

    private float XRotation;
    private float YRotation;

    [SerializeField] float minViewDistance = 25f;
    [SerializeField] Transform playerBody;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        
    }
}
