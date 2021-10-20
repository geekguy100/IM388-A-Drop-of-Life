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
    /// <summary>
    /// Used to activate/deactivate the gas state.
    /// </summary
    [RequireComponent(typeof(MatterStateManager))]
    public abstract class SolidStateController : MonoBehaviour, IMatterStateChanger
    {
        protected MatterStateManager manager;

        protected virtual void Awake()
        {
            manager = GetComponent<MatterStateManager>();
        }

        protected abstract bool CheckSolidCondition();
        protected abstract bool CheckDefaultCondition();

        protected virtual void SwapToSolid()
        {
            if (CheckSolidCondition())
                SwapState(StateOfMatterEnum.ICE);
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