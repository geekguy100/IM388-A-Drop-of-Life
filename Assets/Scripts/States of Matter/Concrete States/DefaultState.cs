/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace GoofyGhosts
{
    /// <summary>
    /// The default state the player is in.
    /// </summary>
    public class DefaultState : IMatterState
    {
        [SerializeField] private DisplayNotifChannelSO displayNotifChannel;

        private StateOfMatterEnum nextState = StateOfMatterEnum.NULL;
        [ShowInInspector][ReadOnly] private bool checkForInteractables;

        #region -- // Initialization // --
        protected override void Awake()
        {
            base.Awake();
            checkForInteractables = true;
        }
        #endregion

        #region -- // Activation / Deactivation // --

        public override void Activate()
        {
            base.Activate();
            checkForInteractables = true;
        }

        public override void Deactivate()
        {
            base.Deactivate();
            checkForInteractables = false;
            displayNotifChannel.Disable();
        }
        #endregion

        #region -- // Check for nearby state swappers // --
        /// <summary>
        /// Assign the next state to swap to if 
        /// nearby any state swappers.
        /// </summary>
        /// <param name="other">The Collider that entered the trigger.</param>
        private void OnTriggerEnter(Collider other)
        {
            if (!checkForInteractables)
                return;

            if (((1 << other.gameObject.layer) & whatIsStateSwapping) > 0)
            {
                StateSwapper swapper = other.GetComponent<StateSwapper>();
                nextState = swapper.GetState();
                displayNotifChannel.RaiseEvent(swapper.GetDisplayNotif());
            }
        }

        /// <summary>
        /// Set the next state to null if not
        /// near any state swappers.
        /// </summary>
        /// <param name="other">The Collider that exited the trigger.</param>
        private void OnTriggerExit(Collider other)
        {
            if (!checkForInteractables)
                return;

            if (((1 << other.gameObject.layer) & whatIsStateSwapping) > 0)
            {
                nextState = StateOfMatterEnum.NULL;
                displayNotifChannel.Disable();
            }
        }
        #endregion

        public override StateOfMatterEnum GetNextState()
        {
            return nextState;
        }

        public override void Jump()
        {
            // TODO: Check for certain amount of jumps to handle
            // swapping to gas state.
        }
    }
}