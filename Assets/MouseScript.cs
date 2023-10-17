using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    [SerializeField] InputManager input;

    [SerializeField] Transform playerBody;
    [SerializeField] float mouseSensitivity = 100f;

    float xRotation = 0f;

    
    void Awake()
    {
        playerBody = this.transform.parent;
        input = playerBody.GetComponent<InputManager>();

        Cursor.lockState = CursorLockMode.Locked;

    }

    
    void Update()
    {
        float mouseX = input.cameraVector.x * mouseSensitivity * Time.deltaTime;
        float mouseY = input.cameraVector.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
