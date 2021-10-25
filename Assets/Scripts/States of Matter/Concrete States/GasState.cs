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
    public class GasState : IMatterState
    {
        [SerializeField] private int requiredJumps;

        public override StateOfMatterEnum GetNextState()
        {
            // Always swap to default.
            return StateOfMatterEnum.DEFAULT;
        }

        public override void Jump(int jumpCount)
        {
            // Propel player.
        }
    }
}
