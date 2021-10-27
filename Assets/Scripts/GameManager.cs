/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace GoofyGhosts
{
    public class GameManager : MonoBehaviour
    {
        private PlayerControls controls;

        private void Awake()
        {
            controls = new PlayerControls();
        }

        private void OnEnable()
        {
            controls.Settings.Reload.performed += _ => SceneManager.LoadScene(1);
            controls.Settings.Menu.performed += _ => { Cursor.lockState = CursorLockMode.None; Cursor.visible = true; SceneManager.LoadScene(0); };

            controls.Settings.Enable();
        }

        private void OnDisable()
        {
            controls.Settings.Disable();
        }
    }
}
