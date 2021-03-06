/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    public class WaterfallEntrance : IStateSwappingObstacle
    {
        [SerializeField] private WaterfallBehaviour parentWaterfall;
        private bool canSwapBack;

        private Interactor currentInteractor;
        public Interactor CurrentInteractor
        {
            get
            {
                return currentInteractor;
            }
            set
            {
                currentInteractor = value;
            }
        }

        public override string GetDisplayInfo()
        {
            return parentWaterfall.GetDisplayInfo();
        }

        public void SetSwapBack(bool canSwapBack)
        {
            this.canSwapBack = canSwapBack;
        }

        public override void Interact(Interactor interactor)
        {
            currentInteractor = interactor;
            parentWaterfall.Interact(interactor);

            // Turn the parent waterfall's collider on.
            parentWaterfall.ToggleCollider(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (canSwapBack)
            {
                // Swap back only if the player is in the waterfall state.
                if (other.TryGetComponent(out MatterStateManager manager) && manager.CurrentState == GetStateOfMatter())
                {
                    print("Swapping back from waterfall entrance");
                    if (currentInteractor == null)
                        OnSwapBack(other.GetComponent<Interactor>());
                    else
                        OnSwapBack(currentInteractor);

                    canSwapBack = false;
                }
            }
        }

        public override void OnSwapBack(Interactor interactor)
        {
            currentInteractor = null;
            parentWaterfall.OnSwapBack(interactor);
        }

        public override string ToString()
        {
            return gameObject.name;
        }

        public override bool CanSwapFrom(StateOfMatterEnum fromState)
        {
            return parentWaterfall.CanSwapFrom(fromState);
        }
    }
}