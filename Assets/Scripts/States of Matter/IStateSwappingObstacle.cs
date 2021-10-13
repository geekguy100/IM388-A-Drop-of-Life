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
    /// Abstract class all state swapping obstacles need to inherit.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public abstract class IStateSwappingObstacle : MonoBehaviour, IMatterStateChanger, IInteractableDisplay, IStateSwapInteractable
    {
        [SerializeField] private StateOfMatterEnum stateToSwapTo;
        [SerializeField] private StateEnumChannelSO stateSwapChannel;

        private Collider col;

        #region -- // Initialization // --
        protected virtual void Awake()
        {
            col = GetComponent<Collider>();
        }

        protected virtual void Start()
        {
            col.isTrigger = true;
        }
        #endregion

        public abstract string GetDisplayInfo();

        public StateOfMatterEnum GetStateOfMatter()
        {
            return stateToSwapTo;
        }

        /// <summary>
        /// Swaps the player's state of matter.
        /// </summary>
        /// <param name="interactor">The GameObject that interacted with 
        /// this interactable.</param>
        public virtual void Interact(GameObject interactor)
        {
            // We need to disable the collider to prevent
            // the player from quickly exiting the trigger
            // due to a change in the player's hitbox on state swap.

            col.enabled = false;
            SwapState(stateToSwapTo);
            StartCoroutine(ReEnableCollider());

            // Reenables the collider at the end of the frame.
            IEnumerator ReEnableCollider()
            {
                yield return new WaitForEndOfFrame();
                col.enabled = true;
            }
        }

        public virtual void SwapState(StateOfMatterEnum value)
        {
            stateSwapChannel.RaiseEvent(value);
        }
    }
}
