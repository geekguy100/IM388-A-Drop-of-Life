/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
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
                interactable = other.gameObject.GetComponent<IInteractable>();
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
    }
}
