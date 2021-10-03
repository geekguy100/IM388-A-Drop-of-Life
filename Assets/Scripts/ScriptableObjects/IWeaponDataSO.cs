/*****************************************************************************
// File Name :         IWeaponDataSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/26/2021
//
// Brief Description : Holds a weapon's data (bullet count, damage, etc.)
*****************************************************************************/
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class IWeaponDataSO : ScriptableObject
{
    [SerializeField] private string weaponName;
    public string WeaponName
    {
        get
        {
            return weaponName;
        }
    }

    [Tooltip("The amount of damage the weapon attacks with.")]
    [SerializeField] private float damage;
    /// <summary>
    /// The amount of damage the weapon attacks with.
    /// </summary>
    public float Damage
    {
        get
        {
            return damage;
        }
    }

    /// <summary>
    /// An enum that holds all of the possible weapon types.
    /// </summary>
    public enum WeaponType { MELEE, RANGED };
    /// <summary>
    /// The weapon's type.
    /// </summary>
    public abstract WeaponType TypeOfWeapon
    {
        get;
    }
}