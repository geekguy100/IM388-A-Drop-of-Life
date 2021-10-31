/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    public class SolidState : IMatterState
    {
        /// <summary>
        /// Reference to the gas camera.
        /// </summary>
        /// <remarks>Solid state uses this camera just like the gas state.</remarks>
        private GameObject gasCamera;
        /// <summary>
        /// Reference to the movement camera.
        /// </summary>
        private GameObject movementCamera;

        /// <summary>
        /// The default layer the player is on;
        /// the layer the player is on in their default state.
        /// </summary>
        private const string DEFAULT_LAYER = "Player";
        /// <summary>
        /// The layer the player is on when in the solid state.
        /// </summary>
        private const string SOLID_LAYER = "Solid State";

        [Tooltip("The amount of hydration required to transition to this state.")]
        [SerializeField] private float requiredHydration;
        /// <summary>
        /// The amount of hydration required to transition to this state.
        /// </summary>
        public float RequiredHydration
        {
            get
            {
                return requiredHydration;
            }
        }

        [Tooltip("All layers which can be broken by this state.")]
        [SerializeField] private LayerMask whatIsBreakable;

        [SerializeField] private GameObject groundedParticles;

        #region -- // Init // --
        /// <summary>
        /// Finding cameras.
        /// </summary>
        private void Start()
        {
            gasCamera = GameObject.FindGameObjectWithTag("GasCamera");
            if (gasCamera == null)
            {
                Debug.LogWarning("[SolidState]: Could not find gas camera. Tag camera 'GasCamera'.");
            }

            movementCamera = GameObject.FindGameObjectWithTag("MovementCamera");
            if (movementCamera == null)
            {
                Debug.LogWarning("[SolidState]: Could not find GameObject tagged 'MovementCamera'.");
            }
        }
        #endregion

        #region -- // Activation / Deactivation // --
        public override void Activate(StateSwapper swapper)
        {
            base.Activate(swapper);
            movementCamera.SetActive(false);
            gasCamera.SetActive(true);

            gameObject.layer = LayerMask.NameToLayer(SOLID_LAYER);

            manager.DecreaseMeterBy(requiredHydration);

            // Setting max jumps to 1 temporarily
            // so we can get the hopping effect.
            Data.MotorData.SetMaxJumps(1);
            motor.SetJumped(true, 1f, true);

            // TODO: Camera shake.
        }

        public override void Deactivate()
        {
            base.Deactivate();
            movementCamera.SetActive(true);
            gasCamera.SetActive(false);

            gameObject.layer = LayerMask.NameToLayer(DEFAULT_LAYER);
        }
        #endregion

        public override void OnGrounded()
        {
            base.OnGrounded();

            // Setting max jumps to 0 so we can't actually perform a jump.
            Data.MotorData.SetMaxJumps(0);

            Instantiate(groundedParticles, transform.position + particleSpawnOffset, Quaternion.identity);
            PerformRaycast();

            // TODO: Camera shake.
        }

        public override StateOfMatterEnum GetNextState()
        {
            return StateOfMatterEnum.DEFAULT;
        }

        /// <summary>
        /// Performs a raycast to check for any breakable objects.
        /// </summary>
        private void PerformRaycast()
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(ray, out RaycastHit hit, 1f, whatIsBreakable))
            {
                BreakableObstacle obstacle = hit.transform.GetComponent<BreakableObstacle>();
                obstacle.Break();
            }
        }
    }
}
