/*****************************************************************************
// File Name :         MeleeWeaponDataSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/26/2021
//
// Brief Description : Holds a melee weapon's data.
*****************************************************************************/
using UnityEngine;

/// <summary>
/// Holds a melee weapon's data.
/// </summary>
[CreateAssetMenu(menuName = "Weapons/Melee Weapon Data", fileName = "New Melee Weapon Data")]
public class MeleeWeaponDataSO : IWeaponDataSO
{
    [Min(0)]
    [Tooltip("The melee weapon's rate of use, similar to a ranged weapon's rate of fire.")]
    [SerializeField] private float useRate;
    /// <summary>
    /// The melee weapon's rate of use, similar to a ranged weapon's rate of fire.
    /// </summary>
    public float UseRate
    {
        get
        {
            return useRate;
        }
    }

    /// <summary>
    /// The type of weapon.
    /// </summary>
    public override WeaponType TypeOfWeapon
    {
        get
        {
            return WeaponType.MELEE;
        }
    }
}
