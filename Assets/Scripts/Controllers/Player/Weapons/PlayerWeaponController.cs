/*****************************************************************************
// File Name :         PlayerWeaponController.cs
// Author :            Kyle Grenier
// Creation Date :     09/26/2021
//
// Brief Description : Accepts player input to use weapons.
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(WeaponHandler))]
public class PlayerWeaponController : MonoBehaviour
{
    /// <summary>
    /// The PlayerControls object.
    /// Used to subscribe to input events.
    /// </summary>
    private PlayerControls controls;

    /// <summary>
    /// Reference to the WeaponHandler component.
    /// </summary>
    private WeaponHandler handler;

    #region -- // Initialization // --
    private void Awake()
    {
        controls = new PlayerControls();
        handler = GetComponent<WeaponHandler>();
    }

    private void OnEnable()
    {
        controls.WeaponsHandling.Fire.performed += OnWeaponFire;
        controls.WeaponsHandling.Enable();
    }

    private void OnDisable()
    {
        controls.WeaponsHandling.Disable();
    }
    #endregion


    
    /// <summary>
    /// Fires the weapon; uses the weapon.
    /// </summary>
    /// <param name="context">The InputAction's callback context.</param>
    private void OnWeaponFire(InputAction.CallbackContext context)
    {
        handler.Fire();
    }

    /// <summary>
    /// Handles swapping weapons.
    /// </summary>
    /// <param name="weapon">The weapon being swapped to.</param>
    private void OnWeaponSwap(IWeapon weapon)
    {
        // If we have a weapon equipped and it's a ranged weapon,
        // destroy the ranged weapon controller component.
        if (handler.HasWeapon())
        {
            if (handler.GetWeaponType() == IWeaponDataSO.WeaponType.RANGED)
            {
                Destroy(GetComponent<PlayerRangedWeaponController>());
            }
        }

        handler.SwapWeapon(weapon);

        // If we're swapping to a ranged weapon, 
        // add the ranged weapon controller component.
        if (weapon.GetWeaponType() == IWeaponDataSO.WeaponType.RANGED)
        {
            gameObject.AddComponent<PlayerRangedWeaponController>();
        }
    }

    /// <summary>
    /// If the player collides with a weapon, swap to it.
    /// </summary>
    /// <param name="other">The collider that entered our trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            OnWeaponSwap(other.GetComponent<IWeapon>());
            other.GetComponent<Collider>().enabled = false;
        }
    }
}