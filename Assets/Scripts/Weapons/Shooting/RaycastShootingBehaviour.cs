/*****************************************************************************
// File Name :         RaycastShootingBehaviour.cs
// Author :            Kyle Grenier
// Creation Date :     09/30/2021
//
// Brief Description : Shoots a bullet via raycasting to from the center of the screen
                       and applying particle effects to simulate a bullet being shot.
*****************************************************************************/
using UnityEngine;

[RequireComponent(typeof(RangedWeapon))]
public class RaycastShootingBehaviour : MonoBehaviour, IShootingBehaviour
{
    /// <summary>
    /// The camera currently in use.
    /// </summary>
    private Camera mainCamera;

    /// <summary>
    /// The layers which the ray can hit.
    /// </summary>
    private LayerMask targetLayers;

    /// <summary>
    /// The RangedWeapon associated with this shooting behaviour.
    /// </summary>
    private RangedWeapon rangedWeapon;

    /// <summary>
    /// Member variable initialization.
    /// </summary>
    private void Awake()
    {
        mainCamera = Camera.main;
        rangedWeapon = GetComponent<RangedWeapon>();
        targetLayers = (rangedWeapon.GetData() as RangedWeaponDataSO).TargetLayers;
    }

    /// <summary>
    /// Shoots a bullet via raycasting.
    /// </summary>
    public void Shoot()
    {
        
    }
}