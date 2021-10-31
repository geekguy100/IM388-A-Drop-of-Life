/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using Sirenix.OdinInspector;
using UnityEngine;
using System.Collections;

namespace GoofyGhosts
{
    public class GasState : IMatterState
    {
        private GameObject gasCamera;
        private GameObject movementCamera;
        private PlayerControls controls;

        private bool isActive;

        [SerializeField][MaxValue(0)] private float propelGravity;

        private Animator anim;

        #region -- // Initialization // --
        protected override void Awake()
        {
            base.Awake();

            isActive = false;
            controls = new PlayerControls();
        }

        private void OnEnable()
        {
            controls.Player.Jump.performed += _ => OnPropelPressed();
            controls.Player.Jump.canceled += _ => OnPropelReleased();

            controls.Player.Jump.Enable();
        }

        private void OnDisable()
        {
            controls.Player.Jump.Disable();
        }

        /// <summary>
        /// Finding cameras.
        /// </summary>
        private void Start()
        {
            manager.OnMeterDepleted += OnPropelReleased;

            gasCamera = GameObject.FindGameObjectWithTag("GasCamera");
            if (gasCamera == null)
            {
                Debug.LogWarning("[GasState]: Could not find gas camera. Tag camera 'GasCamera'.");
            }

            movementCamera = GameObject.FindGameObjectWithTag("MovementCamera");
            if (movementCamera == null)
            {
                Debug.LogWarning("[GasState]: Could not find GameObject tagged 'MovementCamera'.");
            }
        }
        #endregion

        #region -- // Activation / Deactivation // --
        public override void Activate(StateSwapper swapper)
        {
            base.Activate(swapper);

            anim = manager.CurrentModel.GetComponentInChildren<Animator>();
            anim.speed = 0.5f;

            movementCamera.SetActive(false);
            gasCamera.SetActive(true);
            isActive = true;

            // Set the gravity to 0 on activation in case 
            // it was previously changed.
            Data.MotorData.SetGravity(0);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            OnPropelReleased();
            movementCamera.SetActive(true);
            gasCamera.SetActive(false);
            isActive = false;
        }
        #endregion

        public override StateOfMatterEnum GetNextState()
        {
            // Always swap to default.
            return StateOfMatterEnum.DEFAULT;
        }

        /// <summary>
        /// Propels the player into the air on jump.
        /// </summary>
        private void OnPropelPressed()
        {
            if (!isActive || manager.IsMeterDepleted())
                return;

            manager.DecreaseMeter();
            ChangeGravity(propelGravity);

            anim.speed = 2;
        }

        /// <summary>
        /// Resets gravity and stops the meter from changing.
        /// </summary>
        private void OnPropelReleased()
        {
            if (!isActive)
                return;

            manager.StopMeterChange();
            ChangeGravity(0);

            anim.speed = 0.5f;
        }

        private void ChangeGravity(float value)
        {
            StopAllCoroutines();
            StartCoroutine(SetGravity());

            IEnumerator SetGravity()
            {
                float currentValue = Data.MotorData.gravity;
                const float LERP_TIME = 0.3f;
                float currentTime = 0f;

                while (currentTime < LERP_TIME)
                {
                    currentTime += Time.deltaTime;
                    Data.MotorData.SetGravity(Mathf.Lerp(currentValue, value, currentTime / LERP_TIME));
                    yield return null;
                }
            }
        }
    }
}