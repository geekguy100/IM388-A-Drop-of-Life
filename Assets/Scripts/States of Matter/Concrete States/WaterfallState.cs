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

        #region -- // Activation / Deactivation // --
        public override void Activate(StateSwapper swapper)
        {
            base.Activate(swapper);
            waterfall = swapper.GetComponent<WaterfallSwapper>();
            waterfall.Activate(gameObject);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            waterfall.Deactivate();
            waterfall = null;
        }
        #endregion

        public override StateOfMatterEnum GetNextState()
        {
            // Always swap back to default state.
            return StateOfMatterEnum.DEFAULT;
        }
    }
}
