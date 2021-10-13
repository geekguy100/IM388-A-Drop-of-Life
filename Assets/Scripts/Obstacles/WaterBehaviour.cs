/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
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


        /// <summary>
        /// Swaps the player's state of matter.
        /// </summary>
        /// <param name="interactor">The GameObject that interacted with 
        /// this interactable.</param>
        public void Interact(GameObject interactor)
        {
            SwapState(stateToSwapTo);
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
    }
}