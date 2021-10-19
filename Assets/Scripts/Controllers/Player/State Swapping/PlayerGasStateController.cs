/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    [RequireComponent(typeof(CharacterMotor))]
    public class PlayerGasStateController : GasStateController
    {
        private CharacterMotor motor;

        private PlayerControls controls;

        private MouseLook mouseLook;

        private GameObject gasCamera;
        private GameObject movementCamera;

        [Tooltip("The required jumps to enable the gas state.")]
        [SerializeField][Min(1)] private int requiredJumps;
        private int currentJumps;

        #region -- // Initialization // --
        protected override void Awake()
        {
            base.Awake();
            motor = GetComponent<CharacterMotor>();
            mouseLook = GetComponent<MouseLook>();
            controls = new PlayerControls();
        }

        private void Start()
        {
            gasCamera = GameObject.FindGameObjectWithTag("GasCamera");
            gasCamera.SetActive(false);

            movementCamera = GameObject.FindGameObjectWithTag("MovementCamera");
        }

        private void OnEnable()
        {
            motor.OnJumpCountChange += ChangeCurrentJumpCount;

            controls.Interaction.InteractStateSwap.performed += _ => SwapToDefault();
            controls.Interaction.InteractStateSwap.Enable();
        }

        private void OnDisable()
        {
            motor.OnJumpCountChange -= ChangeCurrentJumpCount;

            controls.Interaction.InteractStateSwap.Disable();
        }
        #endregion


        private void ChangeCurrentJumpCount(int currentJumps)
        {
            this.currentJumps = currentJumps;

            if (currentJumps > 0)
                SwapToGas();
        }

        public override void SwapState(StateOfMatterEnum value)
        {
            base.SwapState(value);

            // Toggling cameras
            if (value == StateOfMatterEnum.GAS)
            {
                mouseLook?.EnableGasStateRotation();
                movementCamera.SetActive(false);
                gasCamera.SetActive(true);
            }
            else
            {
                mouseLook?.EnableBaseRotation();
                movementCamera.SetActive(true);
                gasCamera.SetActive(false);
            }
        }

        // Gas
        protected override bool CheckGasCondition()
        {
            return currentJumps >= requiredJumps;
        }


        // Default
        protected override bool CheckDefaultCondition()
        {
            return manager.CurrentState == StateOfMatterEnum.GAS;
        }
    }
}
