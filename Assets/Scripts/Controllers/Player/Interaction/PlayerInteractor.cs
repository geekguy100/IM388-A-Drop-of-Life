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
    public class PlayerInteractor : Interactor
    {
        [Tooltip("The channel that invokes interactable-in-range events.")]
        [SerializeField] private IInteractableChannel interactableChannel;

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

        public override void AssignInteractable(IInteractable other)
        {
            interactable = other;
            interactableChannel.RaiseEvent(interactable, true);
        }

        public override void UnassignInteractable()
        {
            interactableChannel.RaiseEvent(interactable, false);
            interactable = null;
        }
    }
}
