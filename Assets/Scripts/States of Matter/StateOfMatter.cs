/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// A script that holds the behaviour for a particular state of matter.
    /// </summary>
    public class StateOfMatter : MonoBehaviour
    {
        // TODO: Might needs to make this an abstract class,
        // and have each state of matter derive from it, 
        // cause I need to control each state change ability directly.

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

        [SerializeField] private Vector3 particleSpawnOffset;

        /// <summary>
        /// Reference to the CharacterMotor component.
        /// </summary>
        private CharacterMotor motor;

        #region -- // Initialization // --
        /// <summary>
        /// Getting components.
        /// </summary>
        private void Awake()
        {
            motor = GetComponentInParent<CharacterMotor>();
        }
        #endregion

        /// <summary>
        /// Spawning particles / state-specific effects.
        /// </summary>
        public void Activate()
        {
            motor.SwapMotorData(data.MotorData);

            // Instantiate particles if not null.
            if (data.TransitionParticleEffect != null)
                Instantiate(data.TransitionParticleEffect, transform.position + particleSpawnOffset, data.TransitionParticleEffect.transform.rotation);
        }
    }
}