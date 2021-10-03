/*****************************************************************************
// File Name :         IWeapon.cs
// Author :            Kyle Grenier
// Creation Date :     09/26/2021
//
// Brief Description : An interface all weapons must derive from.
                       Defines the base functionality of a weapon.
*****************************************************************************/
using UnityEngine;
/// <summary>
/// An interface all weapons must derive from. 
/// Defines the base functionality of a weapon.
/// </summary>
public abstract class IWeapon : MonoBehaviour
{
    /// <summary>
    /// Set the game object's tag to "Weapon".
    /// </summary>
    protected virtual void Awake()
    {
        gameObject.tag = "Weapon";
    }

    /// <summary>
    /// Activates the weapon; uses the weapon.
    /// </summary>
    public abstract void Fire();

    /// <summary>
    /// Returns the weapon's data.
    /// </summary>
    /// <returns>The weapon's data.</returns>
    public abstract IWeaponDataSO GetData();

    /// <summary>
    /// Returns the weapon's type.
    /// </summary>
    /// <returns>The weapon's type.</returns>
    public IWeaponDataSO.WeaponType GetWeaponType()
    {
        return GetData().TypeOfWeapon;
    }
}