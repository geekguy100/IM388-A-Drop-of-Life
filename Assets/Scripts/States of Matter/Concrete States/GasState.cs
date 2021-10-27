/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class GasState : IMatterState
    {
        private GameObject gasCamera;
        private GameObject movementCamera;
        private PlayerControls controls;

        private bool isActive;

        #region -- // Initialization // --
        protected override void Awake()
        {
            base.Awake();

            isActive = false;
            controls = new PlayerControls();
        }

        private void OnEnable()
        {
            controls.Player.Jump.performed += _ => OnPropelPressed();
            controls.Player.Jump.canceled += _ => OnPropelReleased();

            controls.Player.Jump.Enable();
        }

        private void OnDisable()
        {
            controls.Player.Jump.Disable();
        }

        /// <summary>
        /// Finding cameras.
        /// </summary>
        private void Start()
        {
            gasCamera = GameObject.FindGameObjectWithTag("GasCamera");
            if (gasCamera == null)
            {
                Debug.LogWarning("[GasState]: Could not find gas camera. Tag camera 'GasCamera'.");
            }

            movementCamera = GameObject.FindGameObjectWithTag("MovementCamera");
            if (movementCamera == null)
            {
                Debug.LogWarning("[GasState]: Could not find GameObject tagged 'MovementCamera'.");
            }
        }
        #endregion

        #region -- // Activation / Deactivation // --
        public override void Activate(StateSwapper swapper)
        {
            base.Activate(swapper);
            movementCamera.SetActive(false);
            gasCamera.SetActive(true);
            isActive = true;
        }

        public override void Deactivate()
        {
            base.Deactivate();
            movementCamera.SetActive(true);
            gasCamera.SetActive(false);
            isActive = false;
        }
        #endregion

        public override StateOfMatterEnum GetNextState()
        {
            // Always swap to default.
            return StateOfMatterEnum.DEFAULT;
        }

        /// <summary>
        /// Propels the player into the air on jump.
        /// </summary>
        private void OnPropelPressed()
        {
            if (!isActive)
                return;

            manager.DecreaseMeter();
        }

        private void OnPropelReleased()
        {
            if (!isActive)
                return;

            manager.StopMeterChange();
        }
    }
}