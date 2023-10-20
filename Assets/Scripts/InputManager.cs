using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Attatch this script to player object and call this component to any script that requires an input
    private PlayerActions playerActions;
    

    // These variables below are input reads.
    // Call these variables to use inputs as code
    public Vector2 movementVector = Vector2.zero;
    public Vector2 cameraVector = Vector2.zero;

    public bool jumpInput;
    public bool crouchInput;
    public bool interactInput;
    public bool attackInput;
    public bool inventoryInput;

    private void Awake()
    {
        playerActions = new PlayerActions();
    }

    #region Enable n' Disable
    // Enables and Disables playerActions upon callback to create an Output value, also converts basic buttons to boolean
    private void OnEnable()
    {
        playerActions.Enable();
        playerActions.OnFoot.HorizontalMovement.performed += OnMovementPerformed;
        playerActions.OnFoot.CameraMovement.performed += OnCameraPerformed;

        playerActions.OnFoot.Jump.started += context => jumpInput = true;
        playerActions.OnFoot.Jump.performed += context => jumpInput = true;
        playerActions.OnFoot.Jump.canceled += context => jumpInput = false;

        playerActions.OnFoot.Interact.started += context => interactInput = true;
        playerActions.OnFoot.Interact.performed += context => interactInput = true;
        playerActions.OnFoot.Interact.canceled += context => interactInput = false;

        playerActions.OnFoot.Crouch.started += context => crouchInput = true;
        playerActions.OnFoot.Crouch.performed += context => crouchInput = true;
        playerActions.OnFoot.Crouch.canceled += context => crouchInput = false;

        playerActions.OnFoot.Attack.started += context => attackInput = true;
        playerActions.OnFoot.Attack.performed += context => attackInput = true;
        playerActions.OnFoot.Attack.canceled += context => attackInput = false;

        playerActions.OnFoot.Inventory.started += context => inventoryInput = true;
        playerActions.OnFoot.Inventory.performed += context => inventoryInput = true;
        playerActions.OnFoot.Inventory.canceled += context => inventoryInput = false;
    }

    private void OnDisable()
    {
        playerActions.Disable();
        playerActions.OnFoot.HorizontalMovement.performed -= OnMovementPerformed;
        playerActions.OnFoot.CameraMovement.performed -= OnCameraPerformed;

        playerActions.OnFoot.Jump.started -= context => jumpInput = true;
        playerActions.OnFoot.Jump.performed -= context => jumpInput = true;
        playerActions.OnFoot.Jump.canceled -= context => jumpInput = false;

        playerActions.OnFoot.Crouch.started -= context => crouchInput = true;
        playerActions.OnFoot.Crouch.performed -= context => crouchInput = true;
        playerActions.OnFoot.Crouch.canceled -= context => crouchInput = false;

        playerActions.OnFoot.Interact.started -= context => interactInput = true;
        playerActions.OnFoot.Interact.performed -= context => interactInput = true;
        playerActions.OnFoot.Interact.canceled -= context => interactInput = false;

        playerActions.OnFoot.Attack.started -= context => attackInput = true;
        playerActions.OnFoot.Attack.performed -= context => attackInput = true;
        playerActions.OnFoot.Attack.canceled -= context => attackInput = false;

        playerActions.OnFoot.Inventory.started -= context => inventoryInput = true;
        playerActions.OnFoot.Inventory.performed -= context => inventoryInput = true;
        playerActions.OnFoot.Inventory.canceled -= context => inventoryInput = false;
    }
    #endregion

    #region Input Read to Function
    // Converts Vector2 inputs to Vector2 variables
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        movementVector = value.ReadValue<Vector2>();
    }


    private void OnCameraPerformed(InputAction.CallbackContext value)
    {
        cameraVector = value.ReadValue<Vector2>();
    }
    #endregion

}
