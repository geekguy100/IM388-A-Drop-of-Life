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
        [Tooltip("Channel that invokes interactable-nearby events.")]
        [SerializeField] private IInteractableChannel interactableChannel;

        [Tooltip("The Canvas that displays the notification.")]
        [SerializeField] private GameObject canvas;

        [Tooltip("The TMPro text to display.")]
        [SerializeField] private TextMeshProUGUI displayText;

        /// <summary>
        /// Caching the main camera.
        /// </summary>
        private Transform mainCam;


        #region -- // Initialization // --
        private void OnEnable()
        {
            interactableChannel.OnEventRaised += OnInteractableChange;
        }

        private void OnDisable()
        {
            interactableChannel.OnEventRaised -= OnInteractableChange;
        }

        private void Start()
        {
            mainCam = Camera.main.transform;
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
                StartCoroutine(Rotate());
            }
            else
            {
                canvas.SetActive(false);
            }
        }

        /// <summary>
        /// Rotates the display to face the camera.
        /// </summary>
        private IEnumerator Rotate()
        {
            while (canvas.activeInHierarchy)
            {
                Vector3 dir = transform.root.localPosition - mainCam.localPosition;
                canvas.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);

                yield return null;
            }
        }
    }
}