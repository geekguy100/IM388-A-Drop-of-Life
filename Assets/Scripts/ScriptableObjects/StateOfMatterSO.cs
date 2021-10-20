/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 10/6/2021
*******************************************************************/
using UnityEngine;
using Sirenix.OdinInspector;

namespace GoofyGhosts
{
    /// <summary>
    /// A ScriptableObject that holds data about a sate of matter.
    /// </summary>
    [CreateAssetMenu(menuName = "States of Matter / New State of Matter", fileName = "New State of Matter")]
    public class StateOfMatterSO : ScriptableObject
    {
        [Tooltip("The name of the state of matter.")]
        [SerializeField] private string stateName;
        /// <summary>
        /// The name of the state of matter.
        /// </summary>
        public string StateName
        {
            get
            {
                return stateName;
            }
        }

        [Tooltip("The enum value representing this state.")]
        [SerializeField] private StateOfMatterEnum enumValue;
        public StateOfMatterEnum EnumValue
        {
            get
            {
                return enumValue;
            }
        }

        [Tooltip("The motor data that should be used while in this state.")]
        [SerializeField] private CharacterMotorDataSO motorData;
        /// <summary>
        /// The motor data that should be used in this state.
        /// </summary>
        public CharacterMotorDataSO MotorData
        {
            get
            {
                return motorData;
            }
        }

        [SerializeField] private CharacterControllerData characterControllerData;
        public CharacterControllerData CharacterControllerData
        {
            get
            {
                return characterControllerData;
            }
        }

        [BoxGroup("Transition Fields")]
        [Tooltip("The particle effects that play during the transition to this state.")]
        [SerializeField] private GameObject transitionParticleEffect;
        /// <summary>
        /// The particle effects that play during the transition to this state.
        /// </summary>
        public GameObject TransitionParticleEffect
        {
            get
            {
                return transitionParticleEffect;
            }
        }

        [BoxGroup("Transition Fields")]
        [Tooltip("The particle effects that play when transitioning *from* this state.")]
        [SerializeField] private GameObject transitionFromParticleEffect;
        public GameObject TransitionFromParticleEffect
        {
            get
            {
                return transitionFromParticleEffect;
            }
        }

        [BoxGroup("Transition Fields")]
        [Tooltip("The time (in seconds) it takes to complete the transformation to this state.")]
        [SerializeField] private float transitionTime;
        /// <summary>
        /// The time (in seconds) it takes to complete the transformation to this state.
        /// </summary>
        public float TransitionTime
        {
            get
            {
                return transitionTime;
            }
        }
    }

    /// <summary>
    /// A struct that holds data about a CharacterController component.
    /// </summary>
    [System.Serializable]
    public struct CharacterControllerData
    {
        public float slopeLimit;
        public float slopeOffset;
        public float skinWidth;
        public float minMoveDistance;
        public Vector3 center;
        public float radius;
        public float height;

        /// <summary>
        /// Constructs a new CharacterControllerData struct.
        /// </summary>
        /// <param name="controller">The CharacterController component to grab data from.</param>
        public CharacterControllerData(CharacterController controller)
        {
            this.slopeLimit = controller.slopeLimit;
            this.slopeOffset = controller.stepOffset;
            this.skinWidth = controller.skinWidth;
            this.minMoveDistance = controller.minMoveDistance;
            this.center = controller.center;
            this.radius = controller.radius;
            this.height = controller.height;
        }
    }
}