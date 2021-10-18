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
    /// A channel that carries no value.
    /// </summary>
    [CreateAssetMenu(menuName = "Channels/Void Channel", fileName = "New Void Channel")]
    public class VoidChannelSO : ScriptableObject
    {
        /// <summary>
        /// The UntiyAction to subscribe to.
        /// </summary>
        public UnityAction OnEventRaised;

        /// <summary>
        /// Raises the event.
        /// </summary>
        public void RaiseEvent()
        {
            OnEventRaised?.Invoke();
        }
    }
}
