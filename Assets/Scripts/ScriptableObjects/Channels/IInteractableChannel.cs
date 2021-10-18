/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 10/12/2021
*******************************************************************/
using UnityEngine;
using UnityEngine.Events;

namespace GoofyGhosts
{
    /// <summary>
    /// A channel that carries an IInteractable.
    /// </summary>
    [CreateAssetMenu(menuName ="Channels/IInteractable Channel", fileName = "New IInteractable Channel")]
    public class IInteractableChannel : ScriptableObject
    {
        /// <summary>
        /// The UnityAction invoked.
        /// </summary>
        public UnityAction<IInteractable, bool> OnEventRaised;

        /// <summary>
        /// Raises the event.
        /// </summary>
        /// <param name="value">The IInteractable to pass along.</param>
        /// <param name="inRange">True if the IInteractable is in range of the character.</param>
        public void RaiseEvent(IInteractable value, bool inRange)
        {
            OnEventRaised?.Invoke(value, inRange);
        }
    }
}