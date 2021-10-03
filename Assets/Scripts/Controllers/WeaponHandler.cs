/*****************************************************************************
// File Name :         WeaponHandler.cs
// Author :            Kyle Grenier
// Creation Date :     09/26/2021
//
// Brief Description : A class that enables a character to use weapons.
*****************************************************************************/
using UnityEngine;

/// <summary>
/// A class that enables a character to use weapons.
/// </summary>
public class WeaponHandler : MonoBehaviour
{
    [Tooltip("The weapon currently equipped.")]
    [SerializeField] private IWeapon weapon;
    /// <summary>
    /// The weapon currently equipped.
    /// </summary>
    public IWeapon Weapon
    {
        get
        {
            return weapon;
        }
    }

    /// <summary>
    /// Returns the type of weapon currently equipped.
    /// </summary>
    /// <returns>The type of weapon currently equipped.</returns>
    public IWeaponDataSO.WeaponType GetWeaponType()
    {
        return weapon.GetWeaponType();
    }


    [Tooltip("The Transform which holds the weapon GameObject.")]
    [SerializeField] private Transform weaponSlot;


    /// <summary>
    /// Fires the weapon; uses the weapon.
    /// </summary>
    public void Fire()
    {
        weapon?.Fire();
    }

    /// <summary>
    /// Sets the equipped weapon to the passed in weapon.
    /// </summary>
    /// <param name="weapon">The weapon to use.</param>
    public void SwapWeapon(IWeapon weapon)
    {
        // If we currently have a ranged weapon equipped, destroy the RangedWeaponHandler component.
        if (this.weapon != null)
        {
            if (GetWeaponType() == IWeaponDataSO.WeaponType.RANGED)
            {
                Destroy(GetComponent<RangedWeaponHandler>());
            }

            // TODO: Drop the current weapon. For now, it is being destroyed.
            Destroy(this.weapon.gameObject);
        }

        // Moving the picked up weapon into the slot.
        weapon.transform.SetParent(weaponSlot);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = weaponSlot.localRotation;

        this.weapon = weapon;

        // If we want to switch to a ranged weapon, add the RangedWeaponHandler component.
        if (weapon.GetWeaponType() == IWeaponDataSO.WeaponType.RANGED)
        {
            gameObject.AddComponent<RangedWeaponHandler>();
        }
    }

    /// <summary>
    /// Returns true if the character has a weapon equipped.
    /// </summary>
    /// <returns>True if the character has a weapon equipped.</returns>
    public bool HasWeapon()
    {
        return weapon != null;
    }
}