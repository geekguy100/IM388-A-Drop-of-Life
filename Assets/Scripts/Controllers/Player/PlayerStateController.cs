/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

namespace GoofyGhosts
{
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
            controls.StatesOfMatter.DefaultState.performed += _ => manager.SwapState(0);
            controls.StatesOfMatter.State1.performed += _ => manager.SwapState(1);
            controls.StatesOfMatter.State2.performed += _ => manager.SwapState(2);
            controls.StatesOfMatter.State3.performed += _ => manager.SwapState(3);

            controls.StatesOfMatter.Enable();
        }

        private void OnDisable()
        {
            controls.StatesOfMatter.Disable();
        }
    }
}