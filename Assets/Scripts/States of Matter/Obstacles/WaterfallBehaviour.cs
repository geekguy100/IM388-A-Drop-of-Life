/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Allows the player to climb waterfalls.
    /// </summary>
    public class WaterfallBehaviour : IStateSwappingObstacle
    {
        [Tooltip("The virtual camera associated with this waterfall.")]
        [SerializeField] private GameObject waterfallCamera;

        [Tooltip("The virtual camera associated with player movement.")]
        [SerializeField] private GameObject movementCamera;

        protected override void Start()
        {
            base.Start();
            waterfallCamera.SetActive(false);
        }

        public override string GetDisplayInfo()
        {
            return "Press 'LEFT SHIFT' to climb the waterfall.";
        }

        public override void Interact(GameObject interactor)
        {
            base.Interact(interactor);

            // Enable the waterfall cam.
            movementCamera.SetActive(false);
            waterfallCamera.SetActive(true);
        }

        /// <summary>
        /// Reverts to using the movement camera.
        /// </summary>
        /// <param name="other">The Collider that exited the trigger.</param>
        private void OnTriggerExit(Collider other)
        {
            movementCamera.SetActive(true);
            waterfallCamera.SetActive(false);

            // If the state shifter that exited the trigger
            // is in the water state, make them perform a little hop.
            if (other.TryGetComponent(out MatterStateManager matterStateManager)
                && other.TryGetComponent(out CharacterMotor motor))
            {
                if (matterStateManager.CurrentState == GetStateOfMatter())
                {
                    motor.SetJumped(true, 0.5f, false);
                }
            }

            SwapState(StateOfMatterEnum.DEFAULT);
        }
    }
}
