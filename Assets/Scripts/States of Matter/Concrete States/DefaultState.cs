/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
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
        private DisplayNotif gasNotif;

        private StateOfMatterEnum nextState;

        [ShowInInspector] [ReadOnly] private bool active;
        private bool inAir;

        #region -- // Initialization // --
        protected override void Awake()
        {
            base.Awake();
            nextState = StateOfMatterEnum.NULL;
            active = true;
            gasNotif = new DisplayNotif("Press 'LEFT SHIFT' to transform into a gas.");
        }
        #endregion

        #region -- // Activation / Deactivation // --
        public override void Activate()
        {
            base.Activate();
            active = true;

            // Display the gas notif if not grounded.
            if (!motor.IsGrounded)
            {
                DisplayNotif(gasNotif);
            }
        }

        public override void Deactivate()
        {
            base.Deactivate();
            active = false;
            HideNotif();
        }
        #endregion

        #region -- // Check for nearby state swappers // --
        /// <summary>
        /// Assign the next state to swap to if 
        /// nearby any state swappers.
        /// </summary>
        /// <param name="other">The Collider that entered the trigger.</param>
        private void OnTriggerStay(Collider other)
        {
            if (!active || inAir)
                return;

            if ((((1 << other.gameObject.layer) & whatIsStateSwapping) > 0))
            {
                SetSwapper(other.GetComponent<StateSwapper>());
            }
        }

        /// <summary>
        /// Set the next state to null if not
        /// near any state swappers.
        /// </summary>
        /// <param name="other">The Collider that exited the trigger.</param>
        private void OnTriggerExit(Collider other)
        {
            if (!active)
                return;

            // Run only if we exited the trigger of the current swapper.
            if ((((1 << other.gameObject.layer) & whatIsStateSwapping) > 0))
            {
                nextState = StateOfMatterEnum.NULL;
                HideNotif();
            }
        }

        /// <summary>
        /// Caches the state swapper and displays a notification.
        /// </summary>
        /// <param name="swapper">The StateSwapper to cache.</param>
        private void SetSwapper(StateSwapper swapper)
        {
            nextState = swapper.GetState();
            DisplayNotif(swapper.GetDisplayNotif());
        }
        #endregion

        #region -- // Gas State Checking // --
        /// <summary>
        /// Check if player can swap to gas state given
        /// amount of jumps.
        /// </summary>
        /// <param name="count">The amount of times the player has jumped.</param>
        public override void Jump(int count)
        {
            inAir = true;
            nextState = StateOfMatterEnum.GAS;

            if (active)
                DisplayNotif(gasNotif);
        }

        /// <summary>
        /// Invoked when the player lands on the ground.
        /// </summary>
        protected override void OnGrounded()
        {
            inAir = false;
            nextState = StateOfMatterEnum.NULL;

            if (active)
                HideNotif();
        }
        #endregion

        #region -- // Displaying Notifs // --
        private void DisplayNotif(DisplayNotif? notif)
        {
            displayNotifChannel.RaiseEvent(notif);
        }

        private void HideNotif()
        {
            displayNotifChannel.Disable();
        }
        #endregion

        public override StateOfMatterEnum GetNextState()
        {
            return nextState;
        }
    }
}