/*****************************************************************************
// File Name :         PrefabShootingBehaviour.cs
// Author :            Kyle Grenier
// Creation Date :     09/30/2021
//
// Brief Description : Shoots a ranged weapon via instantiating a bullet prefab.
*****************************************************************************/
using UnityEngine;

[RequireComponent(typeof(RangedWeapon))]
public class PrefabShootingBehaviour : MonoBehaviour, IShootingBehaviour
{
    /// <summary>
    /// The RangedWeapon associated with this shooting behaviour.
    /// </summary>
    private RangedWeapon attachedWeapon;

    /// <summary>
    /// The bullet prefab that will be spawned.
    /// </summary>
    private GameObject bulletPrefab;

    /// <summary>
    /// The Transform to spawn the bullet at.
    /// </summary>
    private Transform bulletSpawnPos;

    private void Awake()
    {
        attachedWeapon = GetComponent<RangedWeapon>();
        bulletPrefab = (attachedWeapon.GetData() as RangedWeaponDataSO).BulletPrefab;
        bulletSpawnPos = attachedWeapon.BulletSpawnPos;
    }

    /// <summary>
    /// Instantiates the bullet prefab.
    /// </summary>
    public void Shoot()
    {
        PrefabBulletBehaviour bulletBehaviour = 
            Instantiate(bulletPrefab, bulletSpawnPos.position, bulletSpawnPos.rotation).
            GetComponent<PrefabBulletBehaviour>();

        bulletBehaviour.Init(attachedWeapon.GetData() as RangedWeaponDataSO);
    }
}