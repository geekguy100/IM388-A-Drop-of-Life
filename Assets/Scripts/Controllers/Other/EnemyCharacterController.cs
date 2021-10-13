/*****************************************************************************
// File Name :         EnemyCharacterController.cs
// Author :            Kyle Grenier / Tristan Blair
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
    /// Waypoint position that enemy patrols around.
    /// </summary>
	private GameObject waypoint;

    private Vector3 inputVector;

    /// <summary>
    /// Initialize components.
    /// </summary>
    private void Awake()
    {
        motor = GetComponent<CharacterMotor>();
        waypoint = GameObject.Find("Waypoint");
    }

    /// <summary>
    /// TEMP: keep the character in place.
    /// </summary>
    private void Update()
    {
        inputVector = new Vector3(1, 0, 0);
        //motor.MoveCharacter(Vector3.zero);
    }

    private void FixedUpdate()
    {
        //motor.MoveCharacter(inputVector);
        transform.RotateAround(waypoint.transform.position, Vector3.right, 20 * Time.deltaTime);
    }
}