/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 10/13/2021
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

        [SerializeField] private WaterfallEntrance waterfallEntrance;

        private Interactor currentInteractor;

        private bool swappedStates;

        protected override void Start()
        {
            base.Start();
            waterfallCamera.SetActive(false);
        }

        public override string GetDisplayInfo()
        {
            return "Press 'LEFT SHIFT' to climb the waterfall.";
        }

        public override void Interact(Interactor interactor)
        {
            if (!CanSwapFrom(interactor.GetComponent<MatterStateManager>().CurrentState))
            {
                interactor.UnassignInteractable();
                return;
            }
            
            currentInteractor = interactor;
            base.Interact(interactor);

            // Disable mouse look so it doesn't mess w/ our seting of the rotation.
            if (interactor.TryGetComponent(out MouseLook mouseLook))
            {
                mouseLook.enabled = false;
            }

            SetRotation(interactor.transform, transform.forward);

            // Enable the waterfall cam.
            movementCamera.SetActive(false);
            waterfallCamera.SetActive(true);

            swappedStates = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out MatterStateManager manager) && manager.CurrentState == GetStateOfMatter())
            {
                waterfallEntrance.SetSwapBack(true);
            }
        }

        /// <summary>
        /// Sets the interactor's rotation.
        /// </summary>
        /// <param name="interactor">The interactor.</param>
        private void SetRotation(Transform interactor, Vector3 forward)
        {
            interactor.forward = forward;
        }

        /// <summary>
        /// Reverts to using the movement camera.
        /// </summary>
        /// <param name="other">The Collider that exited the trigger.</param>
        private void OnTriggerExit(Collider other)
        {
            if (currentInteractor != null)
            {
                OnSwapBack(currentInteractor);
            }
        }

        /// <summary>
        /// Invoked when the player exists the waterfall.
        /// </summary>
        /// <param name="other">The interactor GameObject.</param>
        public override void OnSwapBack(Interactor other)
        {
            waterfallEntrance.SetSwapBack(false);
            waterfallEntrance.CurrentInteractor = null;
            currentInteractor = null;

            // Turn the parent collider back off.
            ToggleCollider(false);

            movementCamera.SetActive(true);
            waterfallCamera.SetActive(false);

            // Re-enable mouse look.
            if (other.TryGetComponent(out MouseLook mouseLook))
            {
                mouseLook.enabled = true;
            }

            // Only rotate the player if they actually swapped states.
            if (swappedStates)
            {
                SetRotation(other.transform, Vector3.forward);
                swappedStates = false;
            }

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

        public override string ToString()
        {
            return gameObject.name;
        }

        public override bool CanSwapFrom(StateOfMatterEnum fromState)
        {
            switch (fromState)
            {
                case StateOfMatterEnum.GAS:
                case StateOfMatterEnum.ICE:
                    return false;
                default:
                    return true;
            }
        }
    }
}
