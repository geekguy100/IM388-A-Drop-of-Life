/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 10/6/2021
*******************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GoofyGhosts
{
    /// <summary>
    /// Manages swapping between the states of matter.
    /// </summary>
    [RequireComponent(typeof(DefaultState))]
    public class MatterStateManager : MonoBehaviour
    {
        #region -- // State Fields // --
        [Tooltip("The current state of matter.")]
        [SerializeField] private IMatterState currentState;
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
        private List<IMatterState> states;

        [Tooltip("The channel that invokes state swap events.")]
        [SerializeField] private StateEnumChannelSO swapStateChannel;
        #endregion

        /// <summary>
        /// Reference to the CharacterController component.
        /// </summary>
        private CharacterController characterController;

        [SerializeField] private GameObject currentModel;


        #region // -- Initialization -- //
        /// <summary>
        /// Initializing components.
        /// </summary>
        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            states = new List<IMatterState>();

            // Store all of the states of matter we can swap to in the list.
            GetComponents(states);

            // Set the current state to the default state.
            currentState = states.Where(t => t.GetType().Equals(typeof(DefaultState))).First();
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

        #region -- // Calling State Methods // --
        public void Jump()
        {
            currentState.Jump();
        }

        public StateOfMatterEnum GetNextState()
        {
            return currentState.GetNextState();
        }
        #endregion

        /// <summary>
        /// Swaps the current state.
        /// </summary>
        /// <param name="value">The value of the state to swap to.</param>
        public void SwapState(StateOfMatterEnum value)
        {
            if (value == StateOfMatterEnum.NULL)
                return;

            //// If we're already in the state we want to swap to,
            //// swap back to default.
            //if (CurrentState == value)
            //{
            //    value = StateOfMatterEnum.DEFAULT;
            //}

            int index = 0;
            foreach (IMatterState state in states)
            {
                if (state.Data.EnumValue == value)
                    break;

                ++index;
            }

            if (index < states.Count)
            {
                // The transition time into the next state.
                float transitionTime = states[index].Data.TransitionTime;

                // Start a coroutine only if we need to.
                // Else, just perform the transition.
                if (transitionTime > 0)
                {
                    StartCoroutine(WaitThenTransition());
                }
                else
                {
                    PerformTransition();
                }

                // Waits the transition time then performs the transition.
                IEnumerator WaitThenTransition()
                {
                    yield return new WaitForSeconds(transitionTime);
                    PerformTransition();
                }

                // Performs the state change transition.
                void PerformTransition()
                {
                    // Deactivate the current state and activate the new one.
                    currentState.Deactivate();
                    if (currentModel != null)
                    {
                        Destroy(currentModel);
                    }

                    currentState = states[index];

                    SetCharacterControllerValues(currentState.Data.CharacterControllerData);

                    currentModel = Instantiate(currentState.Data.Model, transform);
                    currentState.Activate();
                }
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

        /// <summary>
        /// Swaps the current state to the next state.
        /// </summary>
        /// <remarks>Next state is obtained from the current state.</remarks>
        public void SwapToNextState()
        {
            print("Attempting to swap to next state: " + GetNextState());
            SwapState(GetNextState());
        }
    }
}