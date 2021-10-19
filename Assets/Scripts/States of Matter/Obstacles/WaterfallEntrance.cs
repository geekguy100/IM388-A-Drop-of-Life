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

        public override string GetDisplayInfo()
        {
            return parentWaterfall.GetDisplayInfo();
        }

        public void SetSwapBack(bool canSwapBack)
        {
            this.canSwapBack = canSwapBack;
        }

        public override void Interact(GameObject interactor)
        {
            parentWaterfall.Interact(interactor);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (canSwapBack)
            {
                // Swap back only if the player is in the waterfall state.
                if (other.TryGetComponent(out MatterStateManager manager) && manager.CurrentState == GetStateOfMatter())
                {
                    print("Swapping back from waterfall entrance");
                    OnSwapBack(other.gameObject);
                    canSwapBack = false;
                }
            }
        }

        public override void OnSwapBack(GameObject interactor)
        {
            parentWaterfall.OnSwapBack(interactor);
        }
    }
}