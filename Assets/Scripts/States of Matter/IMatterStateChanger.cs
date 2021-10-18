/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/

namespace GoofyGhosts
{
    /// <summary>
    /// Interface for all classes that implement 
    /// state changing behaviour.
    /// </summary>
    public interface IMatterStateChanger
    {
        /// <summary>
        /// Swaps the current state to the state
        /// at the provided index.
        /// </summary>
        /// <param name="value">The value of the state to swap to.</param>
        void SwapState(StateOfMatterEnum value);
    }
}
