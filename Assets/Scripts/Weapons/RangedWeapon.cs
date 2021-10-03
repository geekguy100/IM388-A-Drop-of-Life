/*****************************************************************************
// File Name :         RangedWeapon.cs
// Author :            Kyle Grenier
// Creation Date :     09/26/2021
//
// Brief Description : A weapon that can fire projectiles and be reloaded.
*****************************************************************************/
using UnityEngine;
using System.Collections;

/// <summary>
/// A weapon that can fire projectiles and be reloaded.
/// </summary>
public class RangedWeapon : IWeapon
{
    [Tooltip("The ranged weapon's data.")]
    [SerializeField] private RangedWeaponDataSO weaponData;

    [Tooltip("The Transform indicating where the bullet is fired from.")]
    [SerializeField] private Transform bulletSpawnPos;
    /// <summary>
    /// The Transform indicating where the bullet is fired from.
    /// </summary>
    public Transform BulletSpawnPos
    {
        get
        {
            return bulletSpawnPos;
        }
    }

    #region -- // Non-Serialized Fields // --
    /// <summary>
    /// True if the weapon is being fired (or trying to be fired).
    /// </summary>
    private bool isFiring;

    /// <summary>
    /// True if the weapon is cooling down.
    /// </summary>
    private bool isCoolingDown;

    /// <summary>
    /// True if the weapon is being reloaded.
    /// </summary>
    private bool isReloading;

    /// <summary>
    /// The number of bullets currently in the magazine.
    /// </summary>
    private int bulletCount;

    /// <summary>
    /// The shooting behaviour utilized by this weapon.
    /// </summary>
    private IShootingBehaviour shootingBehaviour;
    #endregion


    /// <summary>
    /// Member variable initialization.
    /// </summary>
    protected override void Awake()
    {
        base.Awake();

        isFiring = false;
        isCoolingDown = false;
        isReloading = false;

        bulletCount = weaponData.MagSize;

        AddShootingBehaviour();
    }

    /// <summary>
    /// Adds the correct IShootingBehaviour component.
    /// </summary>
    private void AddShootingBehaviour()
    {
        if (shootingBehaviour != null)
        {
            Destroy(shootingBehaviour as Component);
        }

        if (weaponData.ShootType == RangedWeaponDataSO.ShootingType.PREFAB)
        {
            shootingBehaviour = gameObject.AddComponent<PrefabShootingBehaviour>();
        }
        else
        {
            shootingBehaviour = gameObject.AddComponent<RaycastShootingBehaviour>();
        }
    }

    #region -- // Firing the Weapon // --
    /// <summary>
    /// Fires the weapon.
    /// </summary>
    public override void Fire()
    {
        // Fire the weapon if it's not cooling down,
        // not reloading, and
        // we have enough bullets in the magazine.
        if (!isCoolingDown && !isReloading && bulletCount > 0)
        {
            isFiring = true;
            StartCoroutine(FireWeapon());
        }
    }

    /// <summary>
    /// Fires the weapon, instantiating the bullet.
    /// </summary>
    private IEnumerator FireWeapon()
    {
        // Continue firing the weapon if it is fully automatic.
        // If it's semi auto, fire a single bullet.
        do
        {
            if (isCoolingDown)
            {
                yield return null;
                continue;
            }

            shootingBehaviour.Shoot();

            if (!weaponData.UnlimitedAmmo)
            {
                bulletCount--;
            }

            StartCoroutine(CooldownWeapon());
            yield return null;
        }
        while (weaponData.RangedType == RangedWeaponDataSO.RangedWeaponType.FULL_AUTO && GetShootingRequirements());
    }

    /// <summary>
    /// Invoked when the character releases the weapon's trigger.
    /// </summary>
    public void ReleaseFire()
    {
        isFiring = false;
    }
    #endregion

    #region -- // Reloading // --
    /// <summary>
    /// Reloads the weapon.
    /// </summary>
    public void Reload()
    {
        // Reload if we're not already reloading and
        // the magazine is not full.
        if (!isReloading && bulletCount < weaponData.MagSize)
        {
            print("Reloading " + weaponData.WeaponName);
            StartCoroutine(ReloadWeapon());
        }
    }

    /// <summary>
    /// Coolsdown the weapon to simulate rate of fire.
    /// During cooldown, the weapon is unable to be fired.
    /// </summary>
    private IEnumerator CooldownWeapon()
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(weaponData.FireRate);
        isCoolingDown = false;
    }

    /// <summary>
    /// Reloads the weapon.
    /// During the reloading process, the weapon is unable to be fired.
    /// </summary>
    private IEnumerator ReloadWeapon()
    {
        isReloading = true;
        yield return new WaitForSeconds(weaponData.ReloadTime);
        isReloading = false;
        bulletCount = weaponData.MagSize;
    }
    #endregion

    /// <summary>
    /// Returns true if a weapon is able to be fired repeatedly.
    /// </summary>
    /// <returns>True if a weapon is able to be fired repeatedly.</returns>
    private bool GetShootingRequirements()
    {
        // Returns true if we're not reloading,
        // holding down the fire button, and have bullets
        // in the magazine.
        return !isReloading && isFiring && bulletCount > 0;
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