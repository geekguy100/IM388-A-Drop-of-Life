/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 10/12/2021
*******************************************************************/
using UnityEngine.Events;
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// A channel that carries an integer value.
    /// </summary>
    [CreateAssetMenu(menuName = "Channels/Int Channel", fileName = "New Int Channel")]
    public class IntChannelSO : ScriptableObject
    {
        /// <summary>
        /// The UntiyAction to subscribe to.
        /// </summary>
        public UnityAction<int> OnEventRaised;

        /// <summary>
        /// Raises the event.
        /// </summary>
        /// <param name="value">The value to send.</param>
        public void RaiseEvent(int value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}
