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
        [Tooltip("The current state of matter.")]
        [SerializeField] private StateOfMatter currentState;
        /// <summary>
        /// The current state of this state swapper.
        /// </summary>
        public StateOfMatterEnum CurrentState
        {
            get
            {
                return currentState.Data.EnumValue;
            }
        }

        [Tooltip("An array of all of the possible states the character can swap to.")]
        [SerializeField] private StateOfMatter[] states;

        [Tooltip("The channel that invokes state swap events.")]
        [SerializeField] private StateEnumChannelSO swapStateChannel;
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

        /// <summary>
        /// Event subbing.
        /// </summary>
        private void OnEnable()
        {
            swapStateChannel.OnEventRaised += SwapState;
        }

        /// <summary>
        /// Event unsubbing.
        /// </summary>
        private void OnDisable()
        {
            swapStateChannel.OnEventRaised -= SwapState;
        }
        #endregion

        /// <summary>
        /// Swaps the current state.
        /// </summary>
        /// <param name="value">The value of the state to swap to.</param>
        public void SwapState(StateOfMatterEnum value)
        {
            // Don't swap if we're in the state we're swapping to.
            if (CurrentState == value)
                return;

            int index = 0;
            foreach (StateOfMatter state in states)
            {
                if (state.Data.EnumValue == value)
                    break;

                ++index;
            }

            if (index < states.Length)
            {
                Destroy(currentState.gameObject);
                currentState = Instantiate(states[index], transform);
                SetCharacterControllerValues(currentState.Data.CharacterControllerData);
                currentState.Activate();
            }
            else
            {
                throw new System.IndexOutOfRangeException("[MatterStateManager]: Cannot swap to state " +
                    "at index " + index + ". It is out of bounds. Ensure you set the enum values of the state you're trying" +
                    "to swap to!");
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