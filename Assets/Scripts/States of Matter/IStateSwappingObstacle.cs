/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created:  
*******************************************************************/
using System.Collections;
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Abstract class all state swapping obstacles need to inherit.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public abstract class IStateSwappingObstacle : MonoBehaviour, IInteractableDisplay, IStateSwapInteractable
    {
        [SerializeField] private StateOfMatterEnum stateToSwapTo;
        [SerializeField] private StateEnumChannelSO stateSwapChannel;

        private Collider col;
        public void ToggleCollider(bool active)
        {
            col.enabled = active;
        }

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

        /// <summary>
        /// Returns the state to swap to.
        /// </summary>
        /// <returns>The state to swap to.</returns>
        public StateOfMatterEnum GetStateOfMatter()
        {
            return stateToSwapTo;
        }

        /// <summary>
        /// Swaps the player's state of matter.
        /// </summary>
        /// <param name="interactor">The GameObject that interacted with 
        /// this interactable.</param>
        public virtual void Interact(Interactor interactor)
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

        public abstract void OnSwapBack(Interactor interactor);

        public override abstract string ToString();

        public abstract bool CanSwapFrom(StateOfMatterEnum fromState);
    }
}
