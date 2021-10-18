/*****************************************************************************
// File Name :         PlayerAimController.cs
// Author :            Kyle Grenier
// Creation Date :     09/27/2021
//
// Brief Description : Controls transitioning between cameras when Moving or ADSing
*****************************************************************************/
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MouseLook))]
public class PlayerAimController : MonoBehaviour
{
    /// <summary>
    /// The PlayerControls object.
    /// </summary>
    private PlayerControls controls;

    [Tooltip("The camera that is active while the player is moving around the game world.")]
    [SerializeField] private GameObject movementCamera;
    [Tooltip("The camera that is active while the player is aiming down their sights of their weapon.")]
    [SerializeField] private GameObject aimCamera;
    [Tooltip("The aim reticle object.")]
    [SerializeField] private GameObject aimReticle;

    /// <summary>
    /// Referece to the MouseLook component.
    /// </summary>
    private MouseLook mouseLook;

    #region -- // Initialization // --
    /// <summary>
    /// Member variable initialization.
    /// </summary>
    private void Awake()
    {
        controls = new PlayerControls();
        mouseLook = GetComponent<MouseLook>();
    }

    /// <summary>
    /// If cameras are null, find them in the scene.
    /// </summary>
    private void Start()
    {
        if (movementCamera == null)
        {
            movementCamera = GameObject.FindGameObjectWithTag("MovementCam");
        }

        if (aimCamera == null)
        {
            aimCamera = GameObject.FindGameObjectWithTag("AimCam");
        }
    }

    /// <summary>
    /// Input event subscribing and enabling.
    /// </summary>
    private void OnEnable()
    {
        // Swap cameras on right click down and right click up.
        controls.WeaponsHandling.Aim.performed += _ => ActivateADSCamera();
        controls.WeaponsHandling.Aim.canceled += _ => ActivateMainCamera();

        controls.WeaponsHandling.Aim.Enable();
    }

    /// <summary>
    /// Disabling input events.
    /// </summary>
    private void OnDisable()
    {
        controls.WeaponsHandling.Aim.Disable();
    }
    #endregion

    /// <summary>
    /// Switches to the ADS camera.
    /// </summary>
    private void ActivateADSCamera()
    {
        movementCamera.SetActive(false);
        aimCamera.SetActive(true);

        mouseLook.EnableADSRotation();
        mouseLook.EnableADSSensitivity();

        if (aimReticle != null)
        {
            StartCoroutine(ShowReticle());
        }
    }

    /// <summary>
    /// Switches to the main camera.
    /// </summary>
    private void ActivateMainCamera()
    {
        StopAllCoroutines();

        mouseLook.EnableBaseRotation();
        mouseLook.EnableBaseSensitivity();

        movementCamera.SetActive(true);
        aimCamera.SetActive(false);

        if (aimReticle != null)
        {
            aimReticle.SetActive(false);
        }
    }

    /// <summary>
    /// Displays the reticle on the screen after some time;
    /// Waits for cameras to blend before showing reticle.
    /// </summary>
    private IEnumerator ShowReticle()
    {
        yield return new WaitForSeconds(0.5f);
        aimReticle.SetActive(true);
    }
}
