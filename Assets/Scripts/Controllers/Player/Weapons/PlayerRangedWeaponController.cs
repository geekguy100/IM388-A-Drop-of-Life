/*****************************************************************************
// File Name :         PlayerRangedWeaponController.cs
// Author :            Kyle Grenier
// Creation Date :     09/26/2021
//
// Brief Description : Handles getting input from the player regarding ranged weapons.
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(RangedWeaponHandler))]
public class PlayerRangedWeaponController : MonoBehaviour
{
    private PlayerControls controls;
    private RangedWeaponHandler handler;

    #region -- // Initialization // --
    private void Awake()
    {
        controls = new PlayerControls();
        handler = GetComponent<RangedWeaponHandler>();
    }

    private void OnEnable()
    {
        controls.WeaponsHandling.Reload.performed += OnWeaponReload;
        controls.WeaponsHandling.Fire.canceled += OnReleaseFire;

        controls.WeaponsHandling.Reload.Enable();
        controls.WeaponsHandling.Fire.Enable();
    }

    private void OnDisable()
    {
        controls.WeaponsHandling.Reload.Disable();
        controls.WeaponsHandling.Fire.Disable();
    }
    #endregion

    /// <summary>
    /// Invoked when the player presses the reload key.
    /// </summary>
    /// <param name="context">The InputAction's callback context.</param>
    private void OnWeaponReload(InputAction.CallbackContext context)
    {
        handler.Reload();
    }

    /// <summary>
    /// Invoked when the player releases the fire key.
    /// </summary>
    /// <param name="context">The InputAction's callback context.</param>
    private void OnReleaseFire(InputAction.CallbackContext context)
    {
        handler.ReleaseFire();   
    }
}