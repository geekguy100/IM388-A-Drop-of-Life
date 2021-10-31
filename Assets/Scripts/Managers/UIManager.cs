/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: Halloween bb
*******************************************************************/
using UnityEngine;
using Sirenix.OdinInspector;

namespace GoofyGhosts
{
    /// <summary>
    /// Manages displaying UI.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        [Tooltip("The GameObject representing the pause menu.")]
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject flowerCollectionCompletePanel;

        [FoldoutGroup("UI Channels")]
        [SerializeField] private VoidChannelSO flowerCollectionCompleteChannel;

        #region -- // Subbing // --
        private void OnEnable()
        {
            flowerCollectionCompleteChannel.OnEventRaised += OnFlowerCollectionComplete;
        }

        private void OnDisable()
        {
            flowerCollectionCompleteChannel.OnEventRaised -= OnFlowerCollectionComplete;
        }

        private void Start()
        {
            GameManager.instance.OnGamePaused += DisplayPauseMenu;
            GameManager.instance.OnGameUnpaused += HidePauseMenu;
        }
        #endregion

        #region -- // Pause Menu // --
        /// <summary>
        /// Displays the pause menu.
        /// </summary>
        private void DisplayPauseMenu()
        {
            pauseMenu.SetActive(true);
        }

        /// <summary>
        /// Hides the pause menu.
        /// </summary>
        private void HidePauseMenu()
        {
            pauseMenu.SetActive(false);
        }
        #endregion

        #region -- // Flower Collection // --
        private void OnFlowerCollectionComplete()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            flowerCollectionCompletePanel.SetActive(true);
        }
        #endregion
    }
}
