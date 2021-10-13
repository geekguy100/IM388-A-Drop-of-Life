/*****************************************************************************
// File Name :         EnemyCharacterController.cs
// Author :            Kyle Grenier
// Creation Date :     10/1/2021
//
// Brief Description : Handles moving an enemy around the game world.
*****************************************************************************/
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class EnemyCharacterController : MonoBehaviour
{
    /// <summary>
    /// Reference to the CharacterMotor component.
    /// </summary>
    private CharacterMotor motor;

    /// <summary>
    /// Initialize components.
    /// </summary>
    private void Awake()
    {
        motor = GetComponent<CharacterMotor>();
    }

    /// <summary>
    /// TEMP: keep the character in place.
    /// </summary>
    private void Update()
    {
        motor.MoveCharacter(Vector3.zero);
    }
}