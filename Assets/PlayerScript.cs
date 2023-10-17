using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerScript : MonoBehaviour
{
    [SerializeField] InputManager input;
    [SerializeField] CharacterController characterController;

    [SerializeField] Vector3 moveDirection = Vector2.zero;

    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private Vector3 playerVelocity;
    private bool groundedPlayer;


    private void Awake()
    {
        input = gameObject.GetComponent<InputManager>();
        characterController = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2;
        }


        Vector3 move = transform.right * input.movementVector.x + transform.forward * input.movementVector.y;
        characterController.Move(move * playerSpeed * Time.deltaTime);

        if(input.jumpInput && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}