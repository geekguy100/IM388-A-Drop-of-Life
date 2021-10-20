/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

namespace GoofyGhosts
{
    [RequireComponent(typeof(CharacterMotor))]
    [RequireComponent(typeof(Interactor))]
    public class PlayerSolidStateController : SolidStateController
    {
        private CharacterMotor motor;

        private PlayerControls controls;

        private Interactor interactor;

        private GameObject gasCamera;
        private GameObject movementCamera;

        [SerializeField] private DisplayNotifChannelSO displayChannel;

        [Tooltip("The required jumps to enable the gas state.")]
        [SerializeField] [Min(1)] private int requiredJumps;
        private int currentJumps;

        #region -- // Initialization // --
        protected override void Awake()
        {
            base.Awake();
            motor = GetComponent<CharacterMotor>();
            controls = new PlayerControls();
            interactor = GetComponent<Interactor>();
        }

        private void Start()
        {
            gasCamera = GameObject.FindGameObjectWithTag("GasCamera");
            if (gasCamera == null)
            {
                Debug.LogWarning("[PlayerSolidStateController]: Could not find GameObject tagged GasCamera.");
            }

            movementCamera = GameObject.FindGameObjectWithTag("MovementCamera");
            if (movementCamera == null)
            {
                Debug.LogWarning("[PlayerSolidStateController]: Could not find GameObject tagged MovementCamera.");
            }

            //controls.Interaction.InteractStateSwap.Dispose();
        }

        private void OnEnable()
        {
            motor.OnJumpCountChange += ChangeCurrentJumpCount;
            motor.OnJumpAttempt += DisplayNotif;

            controls.Interaction.InteractStateSwap.performed += CheckSwap;
            controls.Interaction.InteractStateSwap.Enable();
        }

        private void OnDisable()
        {
            motor.OnJumpCountChange -= ChangeCurrentJumpCount;
            motor.OnJumpAttempt -= DisplayNotif;

            controls.Interaction.InteractStateSwap.Disable();
        }
        #endregion


        /// <summary>
        /// Invoked whenever the player's jump count changes.
        /// </summary>
        /// <param name="currentJumps">The number of times the player has currently jumped.</param>
        private void ChangeCurrentJumpCount(int currentJumps)
        {
            this.currentJumps = currentJumps;
            //if (currentJumps == 0)
            //{
            //    displayChannel.RaiseEvent(new DisplayNotif("", false));
            //}
        }

        /// <summary>
        /// Invoked when the player presses the 'Jump' button.
        /// </summary>
        private void DisplayNotif()
        {
            if (currentJumps > 0)
            {
                if (currentJumps == requiredJumps && manager.CurrentState == StateOfMatterEnum.DEFAULT)
                {
                    displayChannel.RaiseEvent(new DisplayNotif("Press 'LEFT SHIFT' to transform into a solid.", true));
                }
                else if (manager.CurrentState == StateOfMatterEnum.ICE)
                {
                    displayChannel.RaiseEvent(new DisplayNotif("Press 'LEFT SHIFT' to transform back.", true));
                }
            }
            else
            {
                displayChannel.RaiseEvent(new DisplayNotif("", false));
            }
        }

        public override void SwapState(StateOfMatterEnum value)
        {
            base.SwapState(value);

            // Toggling cameras
            if (value == StateOfMatterEnum.ICE)
            {
                movementCamera.SetActive(false);
                gasCamera.SetActive(true);

                //controls.Interaction.InteractStateSwap.performed += _ => SwapToDefault();
            }
            else
            {
                movementCamera.SetActive(true);
                gasCamera.SetActive(false);

                //controls.Interaction.InteractStateSwap.performed += _ => SwapToSolid();
            }
        }

        private void CheckSwap(InputAction.CallbackContext context)
        {
            if (manager.CurrentState == StateOfMatterEnum.DEFAULT)
                SwapToSolid();
            else
                SwapToDefault();
        }

        // Solid
        protected override bool CheckSolidCondition()
        {
            return currentJumps >= requiredJumps && manager.CurrentState == StateOfMatterEnum.DEFAULT;
        }


        // Default
        protected override bool CheckDefaultCondition()
        {
            return manager.CurrentState == StateOfMatterEnum.ICE;
        }
    }
}
