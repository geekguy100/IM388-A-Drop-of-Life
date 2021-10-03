/*****************************************************************************
// File Name :         BulletBehaviour.cs
// Author :            Kyle Grenier
// Creation Date :     09/30/2021
//
// Brief Description : Applies a forwards force to the bullet, shooting it forward.
*****************************************************************************/
using UnityEngine;

/// <summary>
/// Applies a forwards force to the bullet, shooting it forward.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PrefabBulletBehaviour : MonoBehaviour, IBulletBehaviour
{
    /// <summary>
    /// Reference to the Rigidbody component.
    /// </summary>
    private Rigidbody rb;

    [Tooltip("The bullet's data.")]
    [SerializeField] private BulletDataSO bulletData;

    /// <summary>
    /// The layers which to raycast to.
    /// </summary>
    private LayerMask targetLayers;

    /// <summary>
    /// The amount of damage to deal on impact.
    /// </summary>
    private float damageToDeal;


    /// <summary>
    /// The layer all bullets must be in.
    /// </summary>
    const string BULLET_LAYER = "Bullet";


    /// <summary>
    /// Getting components and setting layer.
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // Set layer if not on the correct one.
        if (LayerMask.LayerToName(gameObject.layer) != BULLET_LAYER)
        {
            gameObject.layer = LayerMask.NameToLayer(BULLET_LAYER);
        }
    }

    /// <summary>
    /// Applies a force to the bullet and calls the Destroy() method.
    /// </summary>
    private void Start()
    {
        PerformBehaviour();
        Destroy(gameObject, bulletData.DestroyTime);
    }

    /// <summary>
    /// Adds a force to the bullet, propelling it towards the
    /// center of the screen.
    /// </summary>
    public void PerformBehaviour()
    {
        rb.AddForce(GetShootingDirection() * bulletData.ForwardForce, ForceMode.VelocityChange);

        /// <summary>
        /// Returns the direction to shoot towards.
        /// </summary>
        /// <returns>The direction to shoot towards.</returns>
        Vector3 GetShootingDirection()
        {
            Ray ray = Camera.main.ViewportPointToRay(Vector2.one / 2f);

            // If, after raycasting from the center of the screen, we hit a targetable object,
            // shoot the bullet in that direction.
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, targetLayers))
            {
                return (hit.point - transform.position).normalized;
            }
            // If we did not hit a valid target, shoot towards the center
            // of the screen.
            else
            {
                return ray.direction;
            }
        }
    }

    /// <summary>
    /// When the bullet collides with a collider on the damageable
    /// layers, apply damage to the hit character.
    /// </summary>
    /// <param name="col">The Collision the bullet hit.</param>
    private void OnCollisionEnter(Collision col)
    {
        Health health = col.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damageToDeal);
        }

        //if ((col.gameObject.layer & (1 << bulletData.DamageableLayers.value)) != 0)
        //{
        //    Health health = col.gameObject.GetComponent<Health>();
        //    health.TakeDamage(damageToDeal);
        //}

        Destroy(gameObject);
    }

    /// <summary>
    /// Initializes the target layers.
    /// </summary>
    /// <param name="data">The ranged weapon's data.</param>
    public void Init(RangedWeaponDataSO data)
    {
        targetLayers = data.TargetLayers;
        damageToDeal = data.Damage;
    }
}