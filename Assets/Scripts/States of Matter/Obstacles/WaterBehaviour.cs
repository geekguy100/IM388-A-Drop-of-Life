/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using System.Collections;
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Defines the behaviour for how the player interacts with the water
    /// obstacle.
    /// </summary>
    public class WaterBehaviour : MonoBehaviour, IMatterStateChanger, IInteractableDisplay, IStateSwapInteractable
    {
        [Tooltip("The channel that invokes state swap events.")]
        [SerializeField] private StateEnumChannelSO swapStateChannel;

        [Tooltip("The state to swap to.")]
        [SerializeField] private StateOfMatterEnum stateToSwapTo;

        private Collider col;

        private Interactor currentInteractor;

        /// <summary>
        /// Component initialization.
        /// </summary>
        private void Awake()
        {
            col = GetComponent<Collider>();
        }

        /// <summary>
        /// Swaps the player's state of matter.
        /// </summary>
        /// <param name="interactor">The GameObject that interacted with 
        /// this interactable.</param>
        public void Interact(Interactor interactor)
        {
            currentInteractor = interactor;

            // We need to disable the collider to prevent
            // the player from quickly exiting the trigger
            // due to a change in the player's hitbox on state swap.

            col.enabled = false;
            SwapState(stateToSwapTo);
            StartCoroutine(ReEnableCollider());

            // Reenables the collider at the end of the frame.
            IEnumerator ReEnableCollider()
            {
                yield return new WaitForEndOfFrame();
                col.enabled = true;
            }
        }

        /// <summary>
        /// Swaps the player's state of matter.
        /// </summary>
        /// <param name="value">The value to swap to.</param>
        public void SwapState(StateOfMatterEnum value)
        {
            swapStateChannel.RaiseEvent(value);
        }

        /// <summary>
        /// Swaps back to the default state.
        /// </summary>
        /// <param name="other">The Collider that exited the trigger.</param>
        private void OnTriggerExit(Collider other)
        {
            if (currentInteractor != null)
            {
                OnSwapBack(currentInteractor);
                currentInteractor = null;
            }
        }

        public void OnSwapBack(Interactor other)
        {
            // If the state shifter that exited the trigger
            // is in the water state, make them perform a little hop.
            if (other.TryGetComponent(out MatterStateManager matterStateManager)
                && other.TryGetComponent(out CharacterMotor motor))
            {
                if (matterStateManager.CurrentState == stateToSwapTo)
                {
                    motor.SetJumped(true, 0.5f, false);
                }
            }

            SwapState(StateOfMatterEnum.DEFAULT);
        }

        /// <summary>
        /// Returns the display info.
        /// </summary>
        /// <returns>The display info.</returns>
        public string GetDisplayInfo()
        {
            return "Press 'LEFT SHIFT' to transform into a liquid.";
        }

        /// <summary>
        /// Returns the state of matter that will be swapped to.
        /// </summary>
        /// <returns>The state of matter that will be swapped to.</returns>
        public StateOfMatterEnum GetStateOfMatter()
        {
            return stateToSwapTo;
        }

        public override string ToString()
        {
            return gameObject.name;
        }

        public bool CanSwapFrom(StateOfMatterEnum fromState)
        {
            switch(fromState)
            {
                case StateOfMatterEnum.GAS:
                    return false;
                default:
                    return true;
            }
        }
    }
}