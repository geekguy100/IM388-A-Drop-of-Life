/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 10/6/2021
*******************************************************************/
using UnityEngine;
using UnityEngine.Events;
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
        /// <summary>
        /// Reference to the CharacterController component.
        /// </summary>
        private CharacterController characterController;

        /// <summary>
        /// Reference to the HydrationMeter component.
        /// </summary>
        private HydrationMeter hydrationMeter;
        public UnityAction OnMeterDepleted
        {
            get
            {
                return hydrationMeter.OnDepleted;
            }

            set
            {
                hydrationMeter.OnDepleted = value;
            }
        }
        public UnityAction OnMeterFilled
        {
            get
            {
                return hydrationMeter.OnFilled;
            }

            set
            {
                hydrationMeter.OnFilled = value;
            }
        }

        public UnityAction<StateOfMatterEnum> OnStateSwapped;

        [SerializeField] private GameObject currentModel;
        public GameObject CurrentModel { get { return currentModel; } }

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


        #region // -- Initialization -- //
        /// <summary>
        /// Initializing components.
        /// </summary>
        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            hydrationMeter = GetComponent<HydrationMeter>();

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
        public void Jump(int jumpCount)
        {
            currentState.Jump(jumpCount);
        }

        public void OnGrounded()
        {
            currentState.OnGrounded();
        }

        public void OnUnGrounded()
        {
            currentState.OnUnGrounded();
        }

        public StateOfMatterEnum GetNextState()
        {
            return currentState.GetNextState();
        }
        #endregion

        #region -- // Swapping States // --
        /// <summary>
        /// Swaps the current state.
        /// </summary>
        /// <param name="value">The value of the state to swap to.</param>
        public void SwapState(StateOfMatterEnum value)
        {
            if (value == StateOfMatterEnum.NULL)
                return;

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
                    // Getting the hit StateSwapper if there is one.
                    StateSwapper hitSwapper = currentState.GetSwapper();

                    // Deactivating the current state and destorying
                    // its model so we can spawn in the new one.
                    currentState.Deactivate();
                    if (currentModel != null)
                    {
                        Destroy(currentModel);
                    }

                    currentState = states[index];

                    SetCharacterControllerValues(currentState.Data.CharacterControllerData);

                    currentModel = Instantiate(currentState.Data.Model, transform);
                    currentState.Activate(hitSwapper);

                    OnStateSwapped?.Invoke(CurrentState);
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
            //print("Attempting to swap to next state: " + GetNextState() + " from " + currentState.Data.name);
            SwapState(GetNextState());
        }
        #endregion

        #region -- // Hydration Meter // --
        public void DecreaseMeter()
        {
            hydrationMeter.StartDecrease();
        }

        public void IncreaseMeter()
        {
            hydrationMeter.StartIncrease();
        }

        /// <summary>
        /// Decreases the hydration meter by a set amount.
        /// </summary>
        /// <param name="amount">The amount to decrease the hydration meter by.</param>
        public void DecreaseMeterBy(float amount)
        {
            hydrationMeter.DecreaseBy(amount);
        }

        public void StopMeterChange()
        {
            hydrationMeter.StopChange();
        }

        public float GetHydrationValue()
        {
            return hydrationMeter.CurrentValue;
        }

        public bool IsMeterDepleted()
        {
            return hydrationMeter.isDepleted;
        }

        #endregion
    }
}