/*****************************************************************************
// File Name :         PlayerCharacterController.cs
// Author :            Kyle Grenier
// Creation Date :     09/24/2021
//
// Brief Description : Script responsible for obtaining player input and 
                       applying it to the character motor.
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script responsible for obtaining player input and 
/// applying it to the character motor.
/// </summary>
[RequireComponent(typeof(CharacterMotor))]
public class PlayerCharacterController : MonoBehaviour
{
    /// <summary>
    /// Reference to the attached CharacterMotor component.
    /// </summary>
    private CharacterMotor motor;

    /// <summary>
    /// The object to subscribe events to.
    /// </summary>
    private PlayerControls controls;
    /// <summary>
    /// The InputAction associated with moving the character.
    /// </summary>
    private InputAction movementInputAction;

    /// <summary>
    /// A vector that holds the player's input.
    /// </summary>
    private Vector3 inputVector;

    #region -- // Initialization // --
    /// <summary>
    /// Creating the controls object and getting components.
    /// </summary>
    private void Awake()
    {
        controls = new PlayerControls();
        motor = GetComponent<CharacterMotor>();
    }

    /// <summary>
    /// Event subscribing.
    /// </summary>
    private void OnEnable()
    {
        movementInputAction = controls.Player.Movement;
        controls.Player.Jump.started += _ => motor.SetJumped(true);
        controls.Player.Jump.canceled += _ => motor.SetJumped(false);
        

        movementInputAction.Enable();
        controls.Player.Jump.Enable();
    }

    /// <summary>
    /// Disabling input events.
    /// </summary>
    private void OnDisable()
    {
        movementInputAction.Disable();
        controls.Player.Jump.Disable();
    }
    #endregion

    /// <summary>
    /// Obtain input every frame.
    /// </summary>
    private void Update()
    {
        Vector2 input = movementInputAction.ReadValue<Vector2>();
        inputVector = new Vector3(input.x, 0, input.y);
    }

    /// <summary>
    /// Move the character in FixedUpdate so we 
    /// can interact with Rigidbodies.
    /// </summary>
    private void FixedUpdate()
    {
        motor.MoveCharacter(inputVector);
    }
}