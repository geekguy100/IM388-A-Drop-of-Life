/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    public class SolidState : IMatterState
    {
        public override void OnGrounded()
        {
            base.OnGrounded();
            // TODO: Camera shake.
        }

        public override void Activate(StateSwapper swapper)
        {
            base.Activate(swapper);
            // TODO: Camera shake.
        }

        public override StateOfMatterEnum GetNextState()
        {
            return StateOfMatterEnum.DEFAULT;
        }
    }
}
