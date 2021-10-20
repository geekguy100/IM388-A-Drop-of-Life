/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Destroys the GameObject after a specified time.
    /// </summary>
    public class DestroyAfterTime : MonoBehaviour
    {
        [SerializeField][Min(0)] private float destroyTime;

        private void Start()
        {
            Destroy(gameObject, destroyTime);
        }
    }
}
