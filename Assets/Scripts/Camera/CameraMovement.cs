using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private const float PixelBuffer = 3;

    private Vector2 cameraMotion = Vector2.zero;
    private float cameraSensitivity = .2f;

    private void Start()
    {
        GameObject.Find("InputHandler").GetComponent<PlayerInput>().actions.FindActionMap("Player")["MouseMotion"].performed += OnMouseMotion;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(cameraMotion.x, 0, cameraMotion.y) * cameraSensitivity;
    }

    private void OnMouseMotion(InputAction.CallbackContext context)
    {
        cameraMotion = Vector2.zero;
        Vector2 mousePosition = context.ReadValue<Vector2>();
        if (mousePosition.x <= PixelBuffer)
        {
            cameraMotion.x = -1;
        }
        if (mousePosition.x >= Screen.width - PixelBuffer)
        {
            cameraMotion.x = 1;
        }
        if (mousePosition.y <= PixelBuffer)
        {
            cameraMotion.y = -1;
        }
        if (mousePosition.y >= Screen.height - PixelBuffer)
        {
            cameraMotion.y = 1;
        }
    }
}
