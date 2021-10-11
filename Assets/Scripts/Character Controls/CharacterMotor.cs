/*****************************************************************************
// File Name :         CharacterMotor.cs
// Author :            Kyle Grenier
// Creation Date :     09/24/2021
//
// Brief Description : Script responsible for applying movement to characters.
*****************************************************************************/
using UnityEngine;

/// <summary>
/// Script responsible for applying movement to characters.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class CharacterMotor : MonoBehaviour
{
    [Tooltip("The character's motor data.")]
    [SerializeField] private CharacterMotorDataSO motorData;

    /// <summary>
    /// Reference to the CharacterController component.
    /// </summary>
    private CharacterController characterController;

    /// <summary>
    /// The direction the character wants to move in.
    /// </summary>
    private Vector3 movementDirection;

    /// <summary>
    /// True if the character wants to jump.
    /// i.e. player is pressing Space.
    /// </summary>
    private bool jumped;
    /// <summary>
    /// The number of times the character has jumped
    /// since touching the ground.
    /// </summary>
    private int currentJumps;
    /// <summary>
    /// True of the character jumps from the ground.
    /// Will remain true until the character becomes grounded again.
    /// </summary>
    private bool jumpedFromGround;

    /// <summary>
    /// Getting components.
    /// </summary>
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        currentJumps = 0;
    }

    /// <summary>
    /// Moves the character given an input vector direction.
    /// </summary>
    /// <param name="inputVector">The direction in local space to move the character.</param>
    public void MoveCharacter(Vector3 inputVector)
    {
        // Calculating the velocity to apply to the character.
        Vector3 vel = inputVector * motorData.movementSpeed;

        // Transforming the velocity from local space to world space.
        vel = transform.TransformDirection(vel);

        if (characterController.isGrounded)
        {
            // If we're grounded, set our desired movement direction
            // to our velocity.
            movementDirection = vel;

            // If we're on the ground, set our Y-axis movement direction 
            // to 0 so we're not building momentum each frame.
            movementDirection.y = 0;

            // Set our current jumps to 0 if they are not already.
            if (currentJumps > 0)
            {

                currentJumps = 0;
                jumpedFromGround = false;
            }
        }

        // If the player is jumps, calculate the amount of 
        // upward speed we need to get the player to reach the desired jump height.
        if (GetJumped())
        {
            if (currentJumps < motorData.MaxJumps)
            {
                if (characterController.isGrounded)
                {
                    jumpedFromGround = true;
                }

                movementDirection.y = Mathf.Sqrt(2 * motorData.gravity * motorData.jumpHeight);
                ++currentJumps;
            }

            jumped = false;
        }

        // If we're not grounded...       
        if (!characterController.isGrounded)
        {
            // Take a jump away from the player if they walk
            // off an edge. This prevents the player from
            // double jumping if they walk off an edge and try to jump.
            if (!jumpedFromGround && currentJumps == 0)
            {
                ++currentJumps;
            }

            // Slowly bring our movement towards the user's desired input,
            // but preserve our current y-direction so that the arc of the jump is preserved.
            vel.y = movementDirection.y;
            movementDirection = Vector3.Lerp(movementDirection, vel, motorData.airControl * Time.deltaTime);
        }

        // Subtracting gravity from the movement direction; taking gravity into account.
        movementDirection.y -= motorData.gravity * Time.deltaTime;

        // Apply the movement to the character.
        characterController.Move(movementDirection * Time.deltaTime);
    }

    /// <summary>
    /// Returns true if the character is trying to perform a jump.
    /// </summary>
    /// <returns>True if the character is trying to perform a jump.</returns>
    public bool GetJumped()
    {
        return jumped;
    }

    /// <summary>
    /// Set to true if the character is trying to perform a jump.
    /// </summary>
    /// <param name="jumped">True if the character is trying to perform a jump.</param>
    public void SetJumped(bool jumped)
    {
        this.jumped = jumped;
    }

    /// <summary>
    /// Swaps out the current motor data with the
    /// data provided.
    /// </summary>
    /// <param name="data">The motor data to swap to.</param>
    public void SwapMotorData(CharacterMotorDataSO data)
    {
        motorData = data;
    }
}