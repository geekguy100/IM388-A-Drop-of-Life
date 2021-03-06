/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 10/24/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// A GameObject that is able to invoke state swaps.
    /// </summary>
    public class StateSwapper : MonoBehaviour
    {
        [SerializeField] private StateOfMatterEnum stateToSwapTo;
        [SerializeField] private string displayText;

        /// <summary>
        /// Returns the state to swap to.
        /// </summary>
        /// <returns>The state to swap to.</returns>
        public StateOfMatterEnum GetState()
        {
            return stateToSwapTo;
        }

        public DisplayNotif? GetDisplayNotif()
        {
            if (displayText == string.Empty)
                return null;
            else
                return new DisplayNotif(displayText);
        }
    }
}