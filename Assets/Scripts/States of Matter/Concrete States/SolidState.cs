/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    public class SolidState : IMatterState
    {
        /// <summary>
        /// Reference to the gas camera.
        /// </summary>
        /// <remarks>Solid state uses this camera just like the gas state.</remarks>
        private GameObject gasCamera;
        /// <summary>
        /// Reference to the movement camera.
        /// </summary>
        private GameObject movementCamera;

        #region -- // Init // --
        /// <summary>
        /// Finding cameras.
        /// </summary>
        private void Start()
        {
            gasCamera = GameObject.FindGameObjectWithTag("GasCamera");
            if (gasCamera == null)
            {
                Debug.LogWarning("[SolidState]: Could not find gas camera. Tag camera 'GasCamera'.");
            }

            movementCamera = GameObject.FindGameObjectWithTag("MovementCamera");
            if (movementCamera == null)
            {
                Debug.LogWarning("[SolidState]: Could not find GameObject tagged 'MovementCamera'.");
            }
        }
        #endregion

        #region -- // Activation / Deactivation // --
        public override void Activate(StateSwapper swapper)
        {
            base.Activate(swapper);
            movementCamera.SetActive(false);
            gasCamera.SetActive(true);

            // TODO: Camera shake.
        }

        public override void Deactivate()
        {
            base.Deactivate();
            movementCamera.SetActive(true);
            gasCamera.SetActive(false);
        }
        #endregion

        public override void OnGrounded()
        {
            base.OnGrounded();
            // TODO: Camera shake.
        }

        public override StateOfMatterEnum GetNextState()
        {
            return StateOfMatterEnum.DEFAULT;
        }
    }
}
