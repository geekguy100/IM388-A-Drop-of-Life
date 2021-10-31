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
    public enum GameState { PAUSED, PLAYING }

    public class GameManager : MonoBehaviour
    {
        private PlayerControls controls;
        private GameState gameState;

        public GameState GameState
        {
            get
            {
                return gameState;
            }

            set
            {
                gameState = value;
            }
        }

        public static GameManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }

            controls = new PlayerControls();
            gameState = GameState.PLAYING;
        }

        #region -- // Subbing / Unsubbing // --
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
        #endregion
    }
}
