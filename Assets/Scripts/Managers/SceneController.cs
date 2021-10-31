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
            SceneManager.LoadScene(name);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
