/*****************************************************************************
// File Name :         RangedWeaponDataSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/26/2021
//
// Brief Description : Holds a ranged weapon's data.
*****************************************************************************/
using UnityEngine;
using Sirenix.OdinInspector;

/// <summary>
/// Holds a ranged weapon's data.
/// </summary>
[CreateAssetMenu(menuName = "Weapons/Ranged Weapon Data", fileName = "New Ranged Weapon Data")]
public class RangedWeaponDataSO : IWeaponDataSO
{
    #region -- // Ranged Weapon Types // --
    public enum RangedWeaponType { SEMI_AUTO, FULL_AUTO };

    [FoldoutGroup("Type Selection")]
    [Tooltip("The type of ranged weapon.")]
    [SerializeField] private RangedWeaponType rangedWeaponType;
    /// <summary>
    /// The type of ranged weapon.
    /// </summary>
    public RangedWeaponType RangedType
    {
        get
        {
            return rangedWeaponType;
        }
    }

    /// <summary>
    /// An enum representing the shooting types of a ranged weapon.
    /// </summary>
    public enum ShootingType { PREFAB, RAYCAST };
    [FoldoutGroup("Type Selection")]
    [Tooltip("The shooting type of the ranged weapon.")]
    [OnValueChanged("UpdateBulletPrefab")]
    [SerializeField] private ShootingType shootingType;
    /// <summary>
    /// The shooting type of the ranged weapon.
    /// </summary>
    public ShootingType ShootType
    {
        get
        {
            return shootingType;
        }
    }

    /// <summary>
    /// Automatically sets the bullet prefab to the raycast bullet if 
    /// the shooting type is Raycast.
    /// </summary>
    private void UpdateBulletPrefab()
    {
        if (shootingType == ShootingType.RAYCAST)
        {
            const string PATH = "Assets/Prefabs/Weapons/RaycastBullet";
            if (bulletPrefab == null)
            {
                Debug.LogWarning("[RangedWeaponDataSO]: Could not retrieve raycast bullet! Check that path is correct: " + PATH);
            }
        }
    }

    #endregion

    [ShowIf("shootingType", ShootingType.PREFAB)]
    [FoldoutGroup("Prefab Shooting Fields")]
    [AssetsOnly]
    [Tooltip("The bullet prefab the weapon shoots.")]
    [SerializeField] private GameObject bulletPrefab;
    /// <summary>
    /// The bullet prefab the weapon shoots.
    /// </summary>
    public GameObject BulletPrefab
    {
        get
        {
            if (shootingType == ShootingType.PREFAB)
            {
                return bulletPrefab;
            }
            else
            {
                return null;
            }
        }
    }


    [FoldoutGroup("General Weapon Fields")]
    [Tooltip("The layers which the raycast can hit.")]
    [SerializeField] private LayerMask targetLayers;
    /// <summary>
    /// The layers which the raycast can hit.
    /// </summary>
    public LayerMask TargetLayers
    {
        get
        {
            return targetLayers;
        }
    }

    [FoldoutGroup("General Weapon Fields")]
    [Min(0)]
    [Tooltip("The weapon's magazine size.")]
    [SerializeField] private int magSize;
    /// <summary>
    /// The weapon's magazine size.
    /// </summary>
    public int MagSize
    {
        get
        {
            return magSize;
        }
    }

    [FoldoutGroup("General Weapon Fields")]
    [Min(0)]
    [Tooltip("The weapon's reload time (in seconds).")]
    [SerializeField] private float reloadTime;
    /// <summary>
    /// The weapon's reload time (in seconds).
    /// </summary>
    public float ReloadTime
    {
        get
        {
            return reloadTime;
        }
    }


    [FoldoutGroup("General Weapon Fields")]
    [Min(0)]
    [Tooltip("The weapon's fire rate (in seconds).")]
    [SerializeField] private float fireRate;
    /// <summary>
    /// The weapon's fire rate (in seconds).
    /// </summary>
    public float FireRate
    {
        get
        {
            return fireRate;
        }
    }

    [FoldoutGroup("Misc Fields")]
    [Tooltip("True if the weapon has unlimited ammo.")]
    [SerializeField] private bool unlimitedAmmo;
    /// <summary>
    /// True if the weapon has unlimited ammo.
    /// </summary>
    public bool UnlimitedAmmo
    {
        get
        {
            return unlimitedAmmo;
        }
    }

    /// <summary>
    /// The type of weapon.
    /// </summary>
    public override WeaponType TypeOfWeapon
    {
        get
        {
            return WeaponType.RANGED;
        }
    }
}