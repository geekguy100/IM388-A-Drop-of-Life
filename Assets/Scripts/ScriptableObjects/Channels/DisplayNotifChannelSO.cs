/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine.Events;
using UnityEngine;

namespace GoofyGhosts
{
    [CreateAssetMenu(menuName = "Channels/Display Notification Channel", fileName = "New Display Notification Channel")]
    public class DisplayNotifChannelSO : ScriptableObject
    {
        public UnityAction<DisplayNotif?> OnEventRaised;

        public void RaiseEvent(DisplayNotif? notif)
        {
            if (!notif.HasValue)
                return;

            OnEventRaised?.Invoke(notif);
        }

        /// <summary>
        /// Turns the display off.
        /// </summary>
        public void Disable()
        {
            OnEventRaised.Invoke(new DisplayNotif("", false));
        }
    }

    public struct DisplayNotif
    {
        public string notification;
        public bool display;

        public DisplayNotif(string notification, bool display = true)
        {
            this.notification = notification;
            this.display = display;
        }
    }
}