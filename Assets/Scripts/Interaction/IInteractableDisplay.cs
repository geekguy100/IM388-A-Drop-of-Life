/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// An interface required to be implemented by all 
    /// interactables that can display notifications.
    /// </summary>
    public interface IInteractableDisplay : IInteractable
    {
        /// <summary>
        /// Returns the string to show 
        /// on the notification display.
        /// </summary>
        /// <returns>The string to show on the notification display.</returns>
        string GetDisplayInfo();
    }
}
