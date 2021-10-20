/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Used to activate/deactivate the gas state.
    /// </summary
    [RequireComponent(typeof(MatterStateManager))]
    public abstract class GasStateController : MonoBehaviour, IMatterStateChanger
    {
        protected MatterStateManager manager;

        protected virtual void Awake()
        {
            manager = GetComponent<MatterStateManager>();
        }

        protected abstract bool CheckGasCondition();
        protected abstract bool CheckDefaultCondition();

        protected virtual void SwapToGas()
        {
            if (CheckGasCondition())
                SwapState(StateOfMatterEnum.GAS);
        }

        protected virtual void SwapToDefault()
        {
            if (CheckDefaultCondition())
                SwapState(StateOfMatterEnum.DEFAULT);
        }

        public virtual void SwapState(StateOfMatterEnum value)
        {
            manager.SwapState(value);
        }
    }
}