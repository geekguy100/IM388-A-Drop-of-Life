/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    public class WaterfallSwapper : MonoBehaviour
    {
        private GameObject movementCamera;
        [SerializeField] private GameObject waterfallCamera;

        #region -- // Initialization // --
        /// <summary>
        /// Find movement camera.
        /// </summary>
        private void Start()
        {
            movementCamera = GameObject.FindGameObjectWithTag("MovementCamera");
            if (movementCamera == null)
            {
                Debug.LogWarning("[WaterfallSwapper]: Could not find movement camera. Please tag the VCam responsible" +
                    "for following the player during movement 'MovementCamera'.");
            }
        }
        #endregion

        /// <summary>
        /// Turn waterfall camera on and movement cam off.
        /// </summary>
        /// <param name="player">The player GameObject.</param>
        public void Activate(GameObject player)
        {
            movementCamera.SetActive(false);
            waterfallCamera.SetActive(true);

            if (player.TryGetComponent(out MouseLook mouseLook))
            {
                mouseLook.enabled = false;
            }
        }

        /// <summary>
        /// Turn waterfall cam off and movement cam on.
        /// </summary>
        public void Deactivate(GameObject player)
        {
            movementCamera.SetActive(true);
            waterfallCamera.SetActive(false);

            if (player.TryGetComponent(out MouseLook mouseLook))
            {
                mouseLook.enabled = true;
            }
        }
    }
}