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
        public override StateOfMatterEnum GetNextState()
        {
            return StateOfMatterEnum.DEFAULT;
        }

        public override void Jump(int count)
        {
            // Not using
        }
    }
}
