/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    [RequireComponent(typeof(CharacterMotor))]
    [RequireComponent(typeof(MatterStateManager))]
    public abstract class IMatterState : MonoBehaviour
    {
        // Abstract / Virtual methods
        public virtual void Jump(int jumpCount) { }
        public virtual void OnGrounded() { }
        public abstract StateOfMatterEnum GetNextState();
        public virtual StateSwapper GetSwapper() { return null; }

        #region -- // Data // --
        [Tooltip("The data about this state of matter.")]
        [SerializeField] private StateOfMatterSO data;
        /// <summary>
        /// The data about this state of matter.
        /// </summary>
        public StateOfMatterSO Data
        {
            get
            {
                return data;
            }
        }

        [SerializeField] protected Vector3 particleSpawnOffset;

        [SerializeField] protected LayerMask whatIsStateSwapping;
        #endregion

        /// <summary>
        /// Reference to the MatterStateManager component.
        /// </summary>
        protected MatterStateManager manager;

        /// <summary>
        /// Reference to the CharacterMotor component.
        /// </summary>
        protected CharacterMotor motor;

        #region -- // Initialization // --
        /// <summary>
        /// Getting components.
        /// </summary>
        protected virtual void Awake()
        {
            motor = GetComponent<CharacterMotor>();
            manager = GetComponent<MatterStateManager>();
        }
        #endregion


        /// <summary>
        /// Spawning particles / state-specific effects.
        /// </summary>
        public virtual void Activate(StateSwapper swapper)
        {
            motor.SwapMotorData(data.MotorData);

            // Instantiate particles if not null.
            if (data.TransitionParticleEffect != null)
            {
                Instantiate(data.TransitionParticleEffect, transform.position + particleSpawnOffset, data.TransitionParticleEffect.transform.rotation);
            }
        }

        /// <summary>
        /// Spawns particles and performs de-initialization.
        /// </summary>
        public virtual void Deactivate()
        {
            if (data.TransitionFromParticleEffect != null)
            {
                Instantiate(data.TransitionFromParticleEffect, transform.position + particleSpawnOffset, data.TransitionFromParticleEffect.transform.rotation);
            }
        }
    }
}