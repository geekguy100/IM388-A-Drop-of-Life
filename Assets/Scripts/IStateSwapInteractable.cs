/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/

namespace GoofyGhosts
{
    /// <summary>
    /// An interface all state-swapping interactables must implement.
    /// </summary>
    public interface IStateSwapInteractable : IInteractable
    {
        /// <summary>
        /// Returns the state of matter that will be swapped to.
        /// </summary>
        /// <returns>The state of matter that will be swapped to.</returns>
        StateOfMatterEnum GetStateOfMatter();
    }
}