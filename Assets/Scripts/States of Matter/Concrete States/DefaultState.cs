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
    [RequireComponent(typeof(SolidState))]
    public class DefaultState : IMatterState
    {
        [ShowInInspector] [ReadOnly] private bool active;
        private bool inAir;

        private Animator anim;

        private StateSwapper hitSwapper;
        private SolidState solidState;

        [SerializeField] private DisplayNotifChannelSO displayNotifChannel;
        private DisplayNotif gasNotif;


        #region -- // Initialization // --
        protected override void Awake()
        {
            base.Awake();
            solidState = GetComponent<SolidState>();

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

            // Initializing anim.
            if (anim == null)
            {
                anim = manager.CurrentModel.GetComponentInChildren<Animator>();
            }

            // Setting the Animator to the DefaultState model's attached Animator.
            motor.SetAnimator(anim);

            motor.SetJumped(true, 1f, true);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            active = false;
            hitSwapper = null;

            motor.SetAnimator(null);

            HideNotif();
        }
        #endregion

        #region -- // Check for nearby state swappers // --
        /// <summary>
        /// Assign the next state to swap to if 
        /// any state swappers are nearby.
        /// </summary>
        /// <param name="other">The Collider that entered the trigger.</param>
        private void OnTriggerStay(Collider other)
        {
            if (!active || inAir)
                return;

            if ((((1 << other.gameObject.layer) & whatIsStateSwapping) > 0))
            {
                print("Colliding with state swapper");
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

            if (active)
                DisplayNotif(gasNotif);
        }

        /// <summary>
        /// Invoked when the player lands on the ground.
        /// </summary>
        public override void OnGrounded()
        {
            inAir = false;

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
            // If we are in the air, transition to gas.
            if (inAir)
            {
                return StateOfMatterEnum.GAS;
            }
            // If we have a nearby state swapper, transition to its state.
            else if (hitSwapper != null)
            {
                return hitSwapper.GetState();
            }
            // If we are not in air and have no nearby swappers,
            // check to see if we can transition to the solid state.
            else if (manager.GetHydrationValue() >= solidState.RequiredHydration)
            {
                return StateOfMatterEnum.ICE;
            }
            // If none of the above conditions could be met, 
            // don't transition to anything.
            else
            {
                // TODO: Play animation on hydration bar signifying that we couldn't 
                // transition to it??

                return StateOfMatterEnum.NULL;
            }
        }

        public override StateSwapper GetSwapper()
        {
            return hitSwapper;
        }
    }
}