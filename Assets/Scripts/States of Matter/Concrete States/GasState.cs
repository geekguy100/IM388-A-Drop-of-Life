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

        #region -- // Initialization // --
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
        }

        public override void Deactivate()
        {
            base.Deactivate();
            movementCamera.SetActive(true);
            gasCamera.SetActive(false);
        }
        #endregion

        public override StateOfMatterEnum GetNextState()
        {
            // Always swap to default.
            return StateOfMatterEnum.DEFAULT;
        }

        public override void Jump(int jumpCount)
        {
            // Propel player.
        }
    }
}