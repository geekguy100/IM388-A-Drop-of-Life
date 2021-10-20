/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// An interface all state-swapping interactables must implement.
    /// </summary>
    public interface IStateSwapInteractable : IInteractable, IMatterStateChanger
    {
        /// <summary>
        /// Returns the state of matter that will be swapped to.
        /// </summary>
        /// <returns>The state of matter that will be swapped to.</returns>
        StateOfMatterEnum GetStateOfMatter();

        /// <summary>
        /// Invoked when the interactor swaps out of the state
        /// this interactable put it in.
        /// </summary>
        /// <param name="interactor">The interactor GameObject.</param>
        void OnSwapBack(Interactor interactor);

        /// <summary>
        /// Returns true if this state can be swapped to from
        /// the provided fromState.
        /// </summary>
        /// <param name="fromState">The state to swap from.</param>
        /// <returns>True if this state can be swapped to from
        /// the provided fromState.</returns>
        bool CanSwapFrom(StateOfMatterEnum fromState);
    }
}