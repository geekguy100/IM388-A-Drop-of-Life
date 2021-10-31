/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine.SceneManagement;
using UnityEngine;

namespace GoofyGhosts
{
    public class SceneController : MonoBehaviour
    {
        public void LoadScene(string name)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(name);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
