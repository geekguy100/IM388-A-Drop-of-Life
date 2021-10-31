/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class BreakableObstacle : MonoBehaviour
    {
        [SerializeField] private AudioClipSO breakClip;
        [SerializeField] private AudioClipChannelSO sfxChannel;

        public void Break()
        {
            print("BREAK");
            sfxChannel.RaiseEvent(breakClip);

            Destroy(gameObject);
        }
    }
}
