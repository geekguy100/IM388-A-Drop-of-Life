/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Rotates the transform towards the camera.
    /// </summary>
    public class Billboard : MonoBehaviour
    {
        private Transform cam;

        private void Start()
        {
            cam = Camera.main.transform;
        }

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - cam.position, Vector3.up);
        }
    }
}
