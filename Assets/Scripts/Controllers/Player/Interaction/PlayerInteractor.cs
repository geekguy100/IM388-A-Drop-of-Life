/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 10/13/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// The concrete Player Interactor type.
    /// Assigns interactables via on trigger enter / exit.
    /// </summary>
    [RequireComponent(typeof(MatterStateManager))]
    public class PlayerInteractor : Interactor
    {
        [Tooltip("The channel that invokes interactable-in-range events.")]
        [SerializeField] private IInteractableChannel interactableChannel;

        /// <summary>
        /// Reference to the MatterStateManager component.
        /// </summary>
        private MatterStateManager matterStateManager;

        /// <summary>
        /// Component initialization.
        /// </summary>
        private void Awake()
        {
            matterStateManager = GetComponent<MatterStateManager>();
        }

        /// <summary>
        /// Assigns the interactable.
        /// </summary>
        /// <param name="other">The Collider that entered the trigger.</param>
        private void OnTriggerEnter(Collider other)
        {
            if ((1 << other.gameObject.layer & whatIsInteractable) > 0)
            {
                interactable = other.gameObject.GetComponent<IInteractable>();

                // If we're near a state swapping interactable and it will swap to the state
                // we're already in, return.
                if (CheckSameStateOfMatter(interactable as IStateSwapInteractable))
                {
                    interactableChannel.OnEventRaised(interactable, false);
                    return;
                }

                interactableChannel.OnEventRaised(interactable, true);
            }
        }

        /// <summary>
        /// Unassigns the interactable.
        /// </summary>
        /// <param name="other">The Collider that entered the trigger.</param>
        private void OnTriggerExit(Collider other)
        {
            if ((1 << other.gameObject.layer & whatIsInteractable) > 0)
            {
                interactableChannel.OnEventRaised(interactable, false);
                interactable = null;
            }
        }

        /// <summary>
        /// Returns true if the state we're in is the same 
        /// as the state we're swapping to.
        /// </summary>
        /// <returns>True if the state we're in is the same 
        /// as the state we're swapping to.</returns>
        private bool CheckSameStateOfMatter(IStateSwapInteractable stateSwapInteractable)
        {
            if (stateSwapInteractable != null)
            {
                if (matterStateManager.CurrentState == stateSwapInteractable.GetStateOfMatter())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Performs the interaction.
        /// </summary>
        public override void PerformInteraction()
        {
            IStateSwapInteractable stateSwapInteractable = interactable as IStateSwapInteractable;

            // If we're trying to interact with a state swapping interactable
            // and our current state is the same as the state we're trying to swap to,
            // return.
            if (stateSwapInteractable != null)
            {
                if (CheckSameStateOfMatter(stateSwapInteractable))
                {
                    Debug.Log("Preventing interaction cause of same state swapping.");
                    return;
                }
            }

            base.PerformInteraction();
        }
    }
}
