/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;

namespace GoofyGhosts
{
    public class LiquidState : IMatterState
    {
        /// <summary>
        /// True if the player can swap back to default 
        /// state from this state.
        /// </summary>
        private bool canSwap;
        /// <summary>
        /// True if this is the state in use.
        /// </summary>
        private bool isActive;

        [FoldoutGroup("Audio Fields")]
        [SerializeField] private AudioClipSO splashSFX;
        [FoldoutGroup("Audio Fields")]
        [SerializeField] private AudioClipChannelSO sfxChannel;
        private Animator anim;


        #region -- // Activation / Deactivation // --
        public override void Activate(StateSwapper swapper)
        {
            base.Activate(swapper);
            
            // Initializing the anim field.
            if (anim == null)
            {
                anim = manager.CurrentModel.GetComponentInChildren<Animator>();
            }

            motor.SetAnimator(anim);

            sfxChannel.RaiseEvent(splashSFX);

            isActive = true;
            StartCoroutine(WaitThenEnable());


            IEnumerator WaitThenEnable()
            {
                yield return new WaitForSeconds(0.01f);
                canSwap = true;
            }
        }

        public override void Deactivate()
        {
            base.Deactivate();

            sfxChannel.RaiseEvent(splashSFX);

            motor.SetAnimator(null);
            manager.StopMeterChange();

            isActive = false;
            canSwap = false;
        }
        #endregion

        public override StateOfMatterEnum GetNextState()
        {
            // Always transform back into default state in liquid form.
            return StateOfMatterEnum.DEFAULT;
        }

        /// <summary>
        /// Swaps back to the default state on trigger exit.
        /// </summary>
        /// <param name="other">The Collider that exited the trigger.</param>
        private void OnTriggerExit(Collider other)
        {
            if (!canSwap || !isActive)
                return;

            // Only swap back if we exit the liquid trigger.
            if (((1 << other.gameObject.layer) & whatIsStateSwapping) > 0)
            {
                manager.StopMeterChange();
                manager.SwapToNextState();
            }
        }

        /// <summary>
        /// Fills up hydration meter if in trigger.
        /// </summary>
        /// <param name="other">The Collider we are colliding with.</param>
        private void OnTriggerEnter(Collider other)
        {
            if (!isActive)
                return;

            // Only swap back if we exit the liquid trigger.
            if (((1 << other.gameObject.layer) & whatIsStateSwapping) > 0)
            {
                // Start filling up hydration meter.
                manager.IncreaseMeter();
            }
        }
    }
}