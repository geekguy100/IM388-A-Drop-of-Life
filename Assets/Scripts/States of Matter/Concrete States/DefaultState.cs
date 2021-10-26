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

        private StateSwapper hitSwapper;

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
        public override void Activate(StateSwapper swapper)
        {
            base.Activate(swapper);
            active = true;

            // Display the gas notif if not grounded.
            if (!motor.IsGrounded)
            {
                DisplayNotif(gasNotif);
            }

            motor.SetJumped(true, 1f, true);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            active = false;
            hitSwapper = null;
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

            if ((((1 << other.gameObject.layer) & whatIsStateSwapping) > 0) && hitSwapper == null)
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
            if (!active || inAir)
                return;

            // Run only if we exited the trigger of the current swapper.
            if ((((1 << other.gameObject.layer) & whatIsStateSwapping) > 0))
            {
                nextState = StateOfMatterEnum.NULL;
                hitSwapper = null;
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
            hitSwapper = swapper;
        }
        #endregion

        #region -- // Gas State Checking // --
        /// <summary>
        /// Sets the next state to gas since player is in the air.
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
        public override void OnGrounded()
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

        public override StateSwapper GetSwapper()
        {
            return hitSwapper;
        }
    }
}