/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 10/13/2021
*******************************************************************/
using UnityEngine;
using TMPro;
using System.Collections;

namespace GoofyGhosts
{
    /// <summary>
    /// Follows the player when they are able to interact with a nearby Interactable.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class InteractionNotificationBehaviour : MonoBehaviour
    {
        [SerializeField] private DisplayNotifChannelSO displayChannel;

        private bool isDisplaying;

        [Tooltip("The Canvas that displays the notification.")]
        [SerializeField] private GameObject canvas;

        [Tooltip("The TMPro text to display.")]
        [SerializeField] private TextMeshProUGUI displayText;

        /// <summary>
        /// Caching the main camera.
        /// </summary>
        private Transform mainCam;

        /// <summary>
        /// Reference to the Animator component.
        /// </summary>
        private Animator anim;


        #region -- // Initialization // --
        private void OnEnable()
        {
            displayChannel.OnEventRaised += DisplayNotif;
        }

        private void OnDisable()
        {
            displayChannel.OnEventRaised -= DisplayNotif;
        }

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void Start()
        {
            mainCam = Camera.main.transform;
        }
        #endregion

        private void DisplayNotif(DisplayNotif? notif)
        {
            if (!isDisplaying && notif.Value.display)
            {
                isDisplaying = true;
                displayText.text = notif.Value.notification;
                anim.ResetTrigger("FadeOut");
                anim.SetTrigger("Expand");
                StartCoroutine(Rotate());
            }
            else if (isDisplaying && !notif.Value.display)
            {
                isDisplaying = false;
                anim.SetTrigger("FadeOut");
            }
        }

        private void ActivateCanvas()
        {
            canvas.SetActive(true);
        }

        private void DeactivateCanvas()
        {
            canvas.SetActive(false);
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