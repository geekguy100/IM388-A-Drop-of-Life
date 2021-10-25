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

        private StateOfMatterEnum nextState = StateOfMatterEnum.NULL;
        [ShowInInspector][ReadOnly] private bool active;
        private bool inAir;

        #region -- // Initialization // --
        protected override void Awake()
        {
            base.Awake();
            active = true;
        }

        private void OnEnable()
        {
            motor.OnJumpCountChange += Jump;
            motor.OnGrounded += OnGrounded;
        }

        private void OnDisable()
        {
            motor.OnJumpCountChange -= Jump;
            motor.OnGrounded -= OnGrounded;
        }
        #endregion

        #region -- // Activation / Deactivation // --
        public override void Activate()
        {
            base.Activate();
            active = true;
        }

        public override void Deactivate()
        {
            base.Deactivate();
            active = false;
            displayNotifChannel.Disable();
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
                displayNotifChannel.Disable();
            }
        }

        /// <summary>
        /// Caches the state swapper and displays a notification.
        /// </summary>
        /// <param name="swapper">The StateSwapper to cache.</param>
        private void SetSwapper(StateSwapper swapper)
        {
            nextState = swapper.GetState();
            displayNotifChannel.RaiseEvent(swapper.GetDisplayNotif());
        }
        #endregion

        public override StateOfMatterEnum GetNextState()
        {
            return nextState;
        }

        #region -- // Gas State Checking // --
        /// <summary>
        /// Check if player can swap to gas state given
        /// amount of jumps.
        /// </summary>
        /// <param name="count">The amount of times the player has jumped.</param>
        public override void Jump(int count)
        {
            if (!active)
                return;

            inAir = true;
            nextState = StateOfMatterEnum.GAS;
        }

        /// <summary>
        /// Invoked when the player lands on the ground.
        /// </summary>
        private void OnGrounded()
        {
            if (!active)
                return;

            inAir = false;
            nextState = StateOfMatterEnum.NULL;
        }
        #endregion
    }
}