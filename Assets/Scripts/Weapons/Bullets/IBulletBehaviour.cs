/*****************************************************************************
// File Name :         IBulletBehaviour.cs
// Author :            Kyle Grenier
// Creation Date :     09/30/2021
//
// Brief Description : An interface which all bullet behaviours must implememnt.
*****************************************************************************/


public interface IBulletBehaviour
{
    /// <summary>
    /// Performs the bullet's behaviour.
    /// </summary>
    void PerformBehaviour();

    void Init(RangedWeaponDataSO data);
}