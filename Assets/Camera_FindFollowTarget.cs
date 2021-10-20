/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using Cinemachine;
using UnityEngine;

namespace GoofyGhosts
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class Camera_FindFollowTarget : MonoBehaviour
    {
        private CinemachineVirtualCamera vCam;

        private void Awake()
        {
            vCam = GetComponent<CinemachineVirtualCamera>();
        }

        private void Start()
        {
            GameObject followTarget = GameObject.FindGameObjectWithTag("FollowTarget");

            if (followTarget == null)
            {
                Debug.LogWarning("[" + gameObject.name + "]: Cannot find GameObject tagged 'FollowTarget'. Unable to track player.");
                return;
            }

            vCam.Follow = followTarget.transform;
        }
    }
}
