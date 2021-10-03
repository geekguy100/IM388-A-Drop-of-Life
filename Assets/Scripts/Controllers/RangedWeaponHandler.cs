/*****************************************************************************
// File Name :         RangedWeaponHandler.cs
// Author :            Kyle Grenier
// Creation Date :     09/26/2021
//
// Brief Description : Enables a character to use ranged weapons.
*****************************************************************************/
using UnityEngine;

[RequireComponent(typeof(WeaponHandler))]
public class RangedWeaponHandler : MonoBehaviour
{
    /// <summary>
    /// Referece to the WeaponHandler component.
    /// </summary>
    private WeaponHandler handler;

    /// <summary>
    /// Reference to the RangedWeapon the character has equipped.
    /// </summary>
    private RangedWeapon rangedWeapon;


    /// <summary>
    /// Getting components.
    /// </summary>
    private void Awake()
    {
        handler = GetComponent<WeaponHandler>();
        rangedWeapon = handler.Weapon.GetComponent<RangedWeapon>();
    }

    /// <summary>
    /// Reloads the weapon.
    /// </summary>
    public void Reload()
    {
        rangedWeapon.Reload();
    }

    /// <summary>
    /// Releases the trigger of the ranged weapon.
    /// </summary>
    public void ReleaseFire()
    {
        rangedWeapon.ReleaseFire();
    }
}
