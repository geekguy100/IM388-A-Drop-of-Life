/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 10/6/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Manages swapping between the states of matter.
    /// </summary>
    public class MatterStateManager : MonoBehaviour, IMatterStateChanger
    {
        #region -- // State Fields // --
        /// <summary>
        /// The current state of matter.
        /// </summary>
        [SerializeField] private StateOfMatter currentState;

        /// <summary>
        /// An array of all of the possible states the character can swap to.
        /// </summary>
        [SerializeField] private StateOfMatter[] states;
        #endregion

        /// <summary>
        /// Reference to the CharacterController component.
        /// </summary>
        private CharacterController characterController;

        #region // -- Initialization -- //
        /// <summary>
        /// Initializing components.
        /// </summary>
        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }
        #endregion

        /// <summary>
        /// Swaps the current state.
        /// </summary>
        /// <param name="index">The index of the state to swap to.</param>
        public void SwapState(int index)
        {
            if (index < states.Length)
            {
                print("Swapping to state at index " + index);
                Destroy(currentState.gameObject);
                currentState = Instantiate(states[index], transform);
                SetCharacterControllerValues(currentState.Data.CharacterControllerData);
                currentState.Activate();
            }
            else
            {
                Debug.LogWarning("[MatterStateManager]: Cannot swap to state at index " + index + "." +
                    "It is not set in the states array.");
            }

            // Sets the character controller values to the values associated
            // with the current state.
            void SetCharacterControllerValues(CharacterControllerData data)
            {
                characterController.slopeLimit = data.slopeLimit;
                characterController.stepOffset = data.slopeOffset;
                characterController.skinWidth = data.skinWidth;
                characterController.minMoveDistance = data.minMoveDistance;
                characterController.center = data.center;
                characterController.radius = data.radius;
                characterController.height = data.height;
            }
        }
    }
}