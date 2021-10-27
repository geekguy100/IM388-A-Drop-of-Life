/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using UnityEngine.Events;
using UnityEngine;

namespace GoofyGhosts
{
    [CreateAssetMenu(menuName = "Channels/Hydration Data Channel", fileName = "New Hydration Data Channel")]
    public class HydrationDataChannel : ScriptableObject
    {
        public UnityAction<HydrationMeterData> OnEventRaised;

        public void RaiseEvent(HydrationMeterData data)
        {
            OnEventRaised?.Invoke(data);
        }
    }
}
