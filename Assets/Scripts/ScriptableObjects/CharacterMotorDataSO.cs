/*****************************************************************************
// File Name :         CharacterMotorDataSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/24/2021
//
// Brief Description : A data container that stores a Character's movement fields.
*****************************************************************************/
using UnityEngine;

[CreateAssetMenu(menuName = "Character Data/Motor Data", fileName = "New Character Motor Data")]
public class CharacterMotorDataSO : ScriptableObject
{
    [Tooltip("The character's movement speed.")]
    [SerializeField] private float _movementSpeed = 6;
    /// <summary>
    /// The character's movement speed.
    /// </summary>
    public float movementSpeed
    {
        get
        {
            return _movementSpeed;
        }
    }

    [Tooltip("The character's jump height.")]
    [SerializeField] private float _jumpHeight = 2;
    /// <summary>
    /// The character's jump height.
    /// </summary>
    public float jumpHeight
    {
        get
        {
            return _jumpHeight;
        }
    }

    [Tooltip("Gravity adjustment. A larger value means the character experiences" +
        "a stronger gravitational pull.")]
    [SerializeField] private float _gravity = 20;
    /// <summary>
    /// Gravity adjustment. A larger value means the character experiences 
    /// a stronger gravitational pull.
    /// </summary>
    public float gravity
    {
        get
        {
            return _gravity;
        }
    }

    [Tooltip("The amount of air control the character has. A larger value means" +
        "the character has an easier time moving in the air.")]
    [SerializeField] private float _airControl = 5;
    /// <summary>
    /// The amount of air control the character has. A larger value means 
    /// the character has an easier time moving in the air.
    /// </summary>
    public float airControl
    {
        get
        {
            return _airControl;
        }
    }

    [Tooltip("The maximum times this character can jump" +
        "before having to touch the ground again.")]
    [SerializeField] private int maxJumps = 2;
    /// <summary>
    /// The maximum times this character can jump before having to touch the
    /// ground again.
    /// </summary>
    public int MaxJumps
    {
        get
        {
            return maxJumps;
        }
    }
}
