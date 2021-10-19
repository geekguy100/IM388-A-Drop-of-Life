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
                AssignInteractable(other.GetComponent<IInteractable>());
            }
        }

        /// <summary>
        /// Unassigns the interactable.
        /// </summary>
        /// <param name="other">The Collider that entered the trigger.</param>
        private void OnTriggerExit(Collider other)
        {
            if ((1 << other.gameObject.layer & whatIsInteractable) > 0 && other.GetComponent<IInteractable>() == interactable)
            {
                UnassignInteractable();
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
            base.PerformInteraction();
        }

        /// <summary>
        /// Performs an interaction with a state swapping interactable.
        /// </summary>
        public override void PerformStateSwapInteraction()
        {
            IStateSwapInteractable stateSwapInteractable = interactable as IStateSwapInteractable;

            // If we're trying to interact with a state swapping interactable
            // and our current state is the same as the state we're trying to swap to,
            // swap back.
            if (stateSwapInteractable != null)
            {
                if (CheckSameStateOfMatter(stateSwapInteractable))
                {
                    stateSwapInteractable.OnSwapBack(this);
                    UnassignInteractable();
                    return;
                }

                base.PerformInteraction();
            }
        }

        public override void AssignInteractable(IInteractable other)
        {
            IStateSwapInteractable currentStateSwapInteractable = interactable as IStateSwapInteractable;
            IStateSwapInteractable nextStateSwapInteractable = other as IStateSwapInteractable;

            // If we cannot swap to the next state from the current, return.
            if (interactable != null && !nextStateSwapInteractable.CanSwapFrom(currentStateSwapInteractable.GetStateOfMatter()))
            {
                interactableChannel.OnEventRaised(interactable, false);
                return;
            }


            interactable = other;

            // If we're near a state swapping interactable and it will swap to the state
            // we're already in, return.
            if (CheckSameStateOfMatter(nextStateSwapInteractable))
            {
                interactableChannel.OnEventRaised(interactable, false);
                return;
            }

            interactableChannel.OnEventRaised(interactable, true);
        }

        public override void UnassignInteractable()
        {
            interactableChannel.OnEventRaised(interactable, false);
            interactable = null;
        }
    }
}
