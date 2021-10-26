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
    public class WaterfallState : IMatterState
    {
        private WaterfallSwapper waterfall;

        private bool canSwap;

        #region -- // Activation / Deactivation // --
        public override void Activate(StateSwapper swapper)
        {
            base.Activate(swapper);

            waterfall = swapper.GetComponent<WaterfallSwapper>();
            waterfall.Activate(gameObject);

            SetRotation(transform, waterfall.transform.forward);

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
            waterfall.Deactivate(gameObject);

            SetRotation(transform, Vector3.forward);
            waterfall = null;
            canSwap = false;
        }
        #endregion

        /// <summary>
        /// Sets the interactor's rotation.
        /// </summary>
        /// <param name="player">The player's Transform.</param>
        private void SetRotation(Transform player, Vector3 forward)
        {
            player.forward = forward;
        }

        /// <summary>
        /// Swap back to default state on trigger exit.
        /// </summary>
        /// <param name="other">The Collider that exited the trigger.</param>
        private void OnTriggerExit(Collider other)
        {
            if (!canSwap)
                return;

            // Only swap back if we exit the waterfall trigger.
            if (((1 << other.gameObject.layer) & whatIsStateSwapping) > 0)
            {
                manager.SwapToNextState();
            }
        }

        public override StateOfMatterEnum GetNextState()
        {
            // Always swap back to default state.
            return StateOfMatterEnum.DEFAULT;
        }
    }
}
