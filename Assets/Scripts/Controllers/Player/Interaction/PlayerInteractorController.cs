/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    [RequireComponent(typeof(Interactor))]
    public class PlayerInteractorController : MonoBehaviour
    {
        /// <summary>
        /// Reference to the Interactor component.
        /// </summary>
        private Interactor interactor;

        /// <summary>
        /// Object used to sub to input events.
        /// </summary>
        private PlayerControls controls;

        #region -- // Initialization // --
        /// <summary>
        /// Initializing components.
        /// </summary>
        private void Awake()
        {
            controls = new PlayerControls();
            interactor = GetComponent<Interactor>();
        }

        /// <summary>
        /// Event subbing.
        /// </summary>
        private void OnEnable()
        {
            controls.Interaction.Interact.performed += _ => interactor.PerformInteraction();
            controls.Interaction.Enable();
        }

        /// <summary>
        /// Event unsubbing.
        /// </summary>
        private void OnDisable()
        {
            controls.Interaction.Disable();
        }
        #endregion

    }
}
