/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Handles accepting input for swapping states.
    /// </summary>
    [RequireComponent(typeof(MatterStateManager))]
    public class PlayerStateController : MonoBehaviour
    {
        /// <summary>
        /// Holds access to player input.
        /// </summary>
        private PlayerControls controls;

        /// <summary>
        /// Reference to the MatterStateManager component.
        /// </summary>
        private MatterStateManager manager;

        #region -- // Initialization // --
        /// <summary>
        /// Creating new controls object.
        /// </summary>
        private void Awake()
        {
            controls = new PlayerControls();
            manager = GetComponent<MatterStateManager>();
        }

        private void OnEnable()
        {
            controls.StatesOfMatter.SwapState.performed += _ => manager.SwapToNextState();
            controls.StatesOfMatter.Enable();
        }

        private void OnDisable()
        {
            controls.StatesOfMatter.Disable();
        }
        #endregion
    }
}