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
    /// An enum representing all of the possible states of matter
    /// that can be shifted to.
    /// </summary>
    public enum StateOfMatterEnum { DEFAULT, LIQUID, GAS, ICE };

    /// <summary>
    /// A channel that carries a state enum value.
    /// </summary>
    [CreateAssetMenu(menuName = "Channels/State Enum Channel", fileName = "New State Enum Channel")]
    public class StateEnumChannelSO : ScriptableObject
    {
        /// <summary>
        /// The UntiyAction to subscribe to.
        /// </summary>
        public UnityAction<StateOfMatterEnum> OnEventRaised;

        /// <summary>
        /// Raises the event.
        /// </summary>
        /// <param name="value">The value to send.</param>
        public void RaiseEvent(StateOfMatterEnum value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}
