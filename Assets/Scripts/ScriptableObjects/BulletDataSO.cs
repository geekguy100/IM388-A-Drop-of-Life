/*****************************************************************************
// File Name :         BulletDataSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/30/2021
//
// Brief Description : ScriptableObject that holds data about how a bullet should behave.
*****************************************************************************/
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Weapons/Bullet Data", fileName = "New Bullet Data")]
public class BulletDataSO : ScriptableObject
{
    [Tooltip("The amount of force that is applied to the bullet on spawn.")]
    [FormerlySerializedAs("forwardsForce")]
    [SerializeField] private float forwardForce;
    /// <summary>
    /// The amount of force that is applied to the bullet on spawn.
    /// </summary>
    public float ForwardForce
    {
        get
        {
            return forwardForce;
        }
    }

    [Tooltip("The time in seconds after which the bullet is destroyed.")]
    [SerializeField] private float destroyTime;
    /// <summary>
    /// The time in seconds after which the bullet is destoryed.
    /// </summary>
    public float DestroyTime
    {
        get
        {
            return destroyTime;
        }
    }

    [Tooltip("The layers which contain objects that can be damaged.")]
    [SerializeField] private LayerMask damageableLayers;
    /// <summary>
    /// The layers which contain objects that can be damaged.
    /// </summary>
    public LayerMask DamageableLayers
    {
        get
        {
            return damageableLayers;
        }
    }
}