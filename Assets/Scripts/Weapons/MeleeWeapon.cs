/*****************************************************************************
// File Name :         MeleeWeapon.cs
// Author :            Kyle Grenier
// Creation Date :     09/26/2021
//
// Brief Description : A weapon that is typically used in close-ranged combat.
*****************************************************************************/
using UnityEngine;

/// <summary>
/// A weapon that is typically used in close-ranged combat.
/// </summary>
public class MeleeWeapon : IWeapon
{
    [Tooltip("The weapon's data.")]
    [SerializeField] private MeleeWeaponDataSO weaponData;

    /// <summary>
    /// Swings / Uses the melee weapon.
    /// </summary>
    public override void Fire()
    {
        print("Using melee weapon");
    }

    /// <summary>
    /// Returns the weapon's data.
    /// </summary>
    /// <returns>The weapon's data.</returns>
    public override IWeaponDataSO GetData()
    {
        return weaponData;
    }
}