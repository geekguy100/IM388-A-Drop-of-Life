/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;
using TMPro;
using System.Collections;

namespace GoofyGhosts
{
    /// <summary>
    /// Follows the player when they are able to interact with a nearby Interactable.
    /// </summary>
    public class InteractionNotificationBehaviour : MonoBehaviour
    {
        [Tooltip("The Player's Transform component.")]
        [SerializeField] private Transform player;

        [SerializeField] private Vector3 offset;

        [Tooltip("Channel that invokes interactable-nearby events.")]
        [SerializeField] private IInteractableChannel interactableChannel;

        [Tooltip("The Canvas that displays the notification.")]
        [SerializeField] private GameObject canvas;

        [Tooltip("The TMPro text to display.")]
        [SerializeField] private TextMeshProUGUI displayText;


        #region -- // Initialization // --
        private void OnEnable()
        {
            interactableChannel.OnEventRaised += OnInteractableChange;
        }

        private void OnDisable()
        {
            interactableChannel.OnEventRaised -= OnInteractableChange;
        }
        #endregion

        /// <summary>
        /// Invoked when the player goes near or leaves an interactable.
        /// Only functions if the IInteractable is of type IInteractableDisplay.
        /// </summary>
        /// <param name="interactable">The IInteractable nearby / left.</param>
        /// <param name="inRange">True if the IInteractable is in range and can be interacted with.</param>
        private void OnInteractableChange(IInteractable interactable, bool inRange)
        {
            IInteractableDisplay disp = interactable as IInteractableDisplay;

            if (disp != null && inRange)
            {
                displayText.text = disp.GetDisplayInfo();
                canvas.SetActive(true);
                StartCoroutine(FollowPlayer());
            }
            else
            {
                canvas.SetActive(false);
            }
        }

        /// <summary>
        /// Follows the player with an offset.
        /// </summary>
        private IEnumerator FollowPlayer()
        {
            while(canvas.activeInHierarchy)
            {
                canvas.transform.localPosition = player.localPosition + offset;

                yield return null;
            }
        }
    }
}