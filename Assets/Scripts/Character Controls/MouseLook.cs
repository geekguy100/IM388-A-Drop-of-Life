/*****************************************************************************
// File Name :         MouseLook.cs
// Author :            Kyle Grenier
// Creation Date :     09/24/2021
//
// Brief Description : Rotates the character GameObject via the mouse.
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

/// <summary>
/// Rotates the character GameObject via the mouse.
/// </summary>
public class MouseLook : MonoBehaviour
{
    /// <summary>
    /// The PlayerControls object we use to subscribe to events.
    /// </summary>
    private PlayerControls controls;

    [Tooltip("The head of the character.")]
    [SerializeField] private Transform followTransform;

    [Tooltip("The sensitivity of horizontal rotation.")]
    [SerializeField] private float yawSensitivity;
    [Tooltip("The sensitivity of vertical rotation.")]
    [SerializeField] private float pitchSensitivity;

    [Tooltip("True if the pitch should be inverted.")]
    [SerializeField] private bool inversePitch;

    // Our current rotations.
    private float pitch; // Head rotation
    private float yaw; // Body rotation

    // The initial rotations.
    private Quaternion bodyStartRotation;
    private Quaternion followTransformStartRotation;

    // Limits of head rotation (in degrees).
    [FoldoutGroup("Rotation Limits")]
    [VerticalGroup("Rotation Limits/Base")]
    [BoxGroup("Rotation Limits/Base/Base Rotation Limits")]
    [SerializeField] private float basePitchLowerAngleLimit = -80f;

    [FoldoutGroup("Rotation Limits")]
    [VerticalGroup("Rotation Limits/Base")]
    [BoxGroup("Rotation Limits/Base/Base Rotation Limits")]
    [SerializeField] private float basePitchUpperAngleLimit = 80f;

    [FoldoutGroup("Rotation Limits")]
    [VerticalGroup("Rotation Limits/Gas State")]
    [BoxGroup("Rotation Limits/Gas State/Gas State Rotation Limits")]
    [SerializeField] private float gasPitchLowerAngleLimit = -80f;

    [FoldoutGroup("Rotation Limits")]
    [VerticalGroup("Rotation Limits/Gas State")]
    [BoxGroup("Rotation Limits/Gas State/Gas State Rotation Limits")]
    [SerializeField] private float gasPitchUpperAngleLimit = 80f;

    /// <summary>
    /// The current pitch lower angle limit.
    /// </summary>
    private float pitchLowerAngleLimit;
    /// <summary>
    /// The current pitch upper angle limit.
    /// </summary>
    private float pitchUpperAngleLimit;

    /// <summary>
    /// A vector holding the mouse's movement.
    /// </summary>
    private Vector2 mouseDelta;

    /// <summary>
    /// A field that holds the MouseMove InputAction.
    /// </summary>
    private InputAction mouseMoveAction;


    #region -- // Initialization // --
    /// <summary>
    /// Creating the PlayerControls object.
    /// </summary>
    private void Awake()
    {
        controls = new PlayerControls();
        pitchLowerAngleLimit = basePitchLowerAngleLimit;
        pitchUpperAngleLimit = basePitchUpperAngleLimit;
    }

    /// <summary>
    /// Initializing member variables and hiding the cursor.
    /// </summary>
    private void Start()
    {
        bodyStartRotation = transform.localRotation;
        followTransformStartRotation = followTransform.transform.localRotation;

        // Lock the cursor and make it invisible.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// Subscribing to control events.
    /// </summary>
    private void OnEnable()
    {
        mouseMoveAction = controls.Player.MouseMove;

        controls.Player.MouseMove.Enable();
    }

    /// <summary>
    /// Disabling control events.
    /// </summary>
    private void OnDisable()
    {
        controls.Player.MouseMove.Disable();
    }
    #endregion

    /// <summary>
    /// Get mouse delta every frame.
    /// </summary>
    private void Update()
    {
        // Keep track of the delta each frame.
        mouseDelta = mouseMoveAction.ReadValue<Vector2>();
    }

    /// <summary>
    /// Rotate the camera.
    /// </summary>
    private void LateUpdate()
    {
        // Perform rotation.
        // Obtain rotation amounts taking sensitivity and delta time into consideration.
        float horizontalRot = mouseDelta.x * Time.deltaTime * yawSensitivity;
        float verticalRot = mouseDelta.y * Time.deltaTime * pitchSensitivity;

        // Add our inputs to the yaw and pitch.
        yaw += horizontalRot;
        pitch += (inversePitch) ? -verticalRot : verticalRot;

        // Clamp the pitch to set values.
        pitch = Mathf.Clamp(pitch, pitchLowerAngleLimit, pitchUpperAngleLimit);

        // Calculate new rotations given input.
        Quaternion bodyRotation = Quaternion.AngleAxis(yaw, Vector3.up);
        Quaternion headRotation = Quaternion.AngleAxis(pitch, Vector3.right);

        // Rotate the character.
        RotateCharacter(bodyRotation, headRotation);
    }

    /// <summary>
    /// Applies the rotation to the character and the follow transform (head).
    /// </summary>
    /// <param name="bodyRotation">The new character rotation.</param>
    /// <param name="headRotation">The new follow transform rotation.</param>
    private void RotateCharacter(Quaternion bodyRotation, Quaternion headRotation)
    {
        // Create new rotations for the body and head by combining them
        // with their start rotations.
        transform.localRotation = bodyStartRotation * bodyRotation;
        followTransform.transform.localRotation = followTransformStartRotation * headRotation;
    }

    /// <summary>
    /// Enables the ADS sensitivity.
    /// </summary>
    public void EnableADSSensitivity()
    {

    }

    /// <summary>
    /// Enables the base sensitivity.
    /// </summary>
    public void EnableBaseSensitivity()
    {

    }

    /// <summary>
    /// Enable Gas state rotation limits.
    /// </summary>
    public void EnableGasStateRotation()
    {
        pitchLowerAngleLimit = gasPitchLowerAngleLimit;
        pitchUpperAngleLimit = gasPitchUpperAngleLimit;
    }

    /// <summary>
    /// Enable base rotation limits.
    /// </summary>
    public void EnableBaseRotation()
    {
        pitchLowerAngleLimit = basePitchLowerAngleLimit;
        pitchUpperAngleLimit = basePitchUpperAngleLimit;
    }
}