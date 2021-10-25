/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using UnityEngine;
using System.Collections;

namespace GoofyGhosts
{
    public class LiquidState : IMatterState
    {
        private bool canSwap;

        #region -- // Activation / Deactivation // --
        public override void Activate()
        {
            base.Activate();
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
            canSwap = false;
        }
        #endregion


        public override void Jump()
        {
            // Not used
        }

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
            if (!canSwap)
                return;

            // Only swap back if we exit the liquid trigger.
            if (((1 << other.gameObject.layer) & whatIsStateSwapping) > 0)
            {
                manager.SwapToNextState();
            }
        }
    }
}
