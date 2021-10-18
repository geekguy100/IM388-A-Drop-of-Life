/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// An interface all interactables must implement.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// Performs the interactable's interaction behaviour.
        /// </summary>
        /// <param name="interactor">The GameObject that interacted with 
        /// this interactable.</param>
        void Interact(Interactor interactor);
    }
}
