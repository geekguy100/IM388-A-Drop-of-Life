/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// A component that enables a GameObject to interact
    /// with IInteractables in the game world.
    /// </summary>
    public abstract class Interactor : MonoBehaviour
    {
        [Tooltip("All layers that are interactable.")]
        [SerializeField] protected LayerMask whatIsInteractable;

        /// <summary>
        /// The nearby interactable.
        /// </summary>
        protected IInteractable interactable;

        public bool HasInteractable()
        {
            return interactable != null;
        }

        /// <summary>
        /// Performs the interaction.
        /// </summary>
        public virtual void PerformInteraction()
        {
            if (interactable != null)
            {
                interactable.Interact(this);
            }
            else
            {
                Debug.Log("[" + gameObject.name + "]: Interactor has no interactable; Cannot perform interaction.");
            }
        }

        public abstract void UnassignInteractable();
        public abstract void AssignInteractable(IInteractable interactable);
    }
}
