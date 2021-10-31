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
    public class FlowerCollectionManager : MonoBehaviour
    {
        /// <summary>
        /// The number of flowers collected.
        /// </summary>
        private int flowersCollected;
        /// <summary>
        /// The required number of flowers to be collected in order
        /// to clear the level.
        /// </summary>
        private int requiredNumFlowers;

        [Tooltip("Channel used to receive flower collection events from.")]
        [SerializeField] private VoidChannelSO flowerCollectionChannel;

        #region -- // Subbing / Unsubbing // --
        private void OnEnable()
        {
            flowerCollectionChannel.OnEventRaised += OnFlowerCollected;
        }

        private void OnDisable()
        {
            flowerCollectionChannel.OnEventRaised -= OnFlowerCollected;
        }
        #endregion

        #region -- // Initialization // --
        /// <summary>
        /// Initializing the required number of flowers to be collected.
        /// </summary>
        private void Start()
        {
            requiredNumFlowers = GameObject.FindGameObjectsWithTag("Flower").Length;
            print("Found flowers: " + requiredNumFlowers);
        }
        #endregion

        /// <summary>
        /// Increaase the number of flowers we have collected.
        /// </summary>
        private void OnFlowerCollected()
        {
            ++flowersCollected;
            if (flowersCollected >= requiredNumFlowers)
            {

            }
        }
    }
}
