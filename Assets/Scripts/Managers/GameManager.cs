/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// An enum representing all of the possible game states.
    /// </summary>
    public enum GameState { PAUSED, PLAYING }

    /// <summary>
    /// Script that handles managing the game's state.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private PlayerControls controls;
        private GameState gameState;
        private GameState previousState;

        public GameState GameState
        {
            get
            {
                return gameState;
            }

            set
            {
                previousState = gameState;

                if (gameState == GameState.PAUSED)
                {
                    PauseGame();
                }
                else if (previousState == GameState.PAUSED)
                {
                    UnpauseGame();
                }
                else
                {
                    gameState = value;
                }
            }
        }
        public UnityAction OnGamePaused;
        public UnityAction OnGameUnpaused;

        public static GameManager instance;

        #region -- // Init // --
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
                return;
            }

            controls = new PlayerControls();
            gameState = GameState.PLAYING;
        }
        #endregion

        #region -- // Event Subbing / Unsubbing // --
        private void OnEnable()
        {
            controls.Settings.Pause.performed += _ => 
            {
                // Toggles pausing / unpausing the game.
                if (gameState == GameState.PLAYING)
                    PauseGame();
                else if (gameState == GameState.PAUSED)
                    UnpauseGame();
            };

            controls.Settings.Enable();
        }

        private void OnDisable()
        {
            controls.Settings.Disable();
        }
        #endregion

        /// <summary>
        /// Pauses the game.
        /// </summary>
        public void PauseGame()
        {
            // Time scale set from outside source - let 
            // that handle it.
            if (Time.timeScale == 0)
                return;

            gameState = GameState.PAUSED;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0;
            OnGamePaused?.Invoke();
        }

        /// <summary>
        /// Unpauses the game.
        /// </summary>
        public void UnpauseGame()
        {
            gameState = GameState.PLAYING;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Time.timeScale = 1;
            OnGameUnpaused?.Invoke();
        }
    }
}
