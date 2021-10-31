using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class UI_Animation : MonoBehaviour
    {

        public GameObject waterIcon, iceIcon, steamIcon;

        private Animator anim;

        private MatterStateManager matterStateManager;

        void Awake()
        {
            matterStateManager = GetComponent<MatterStateManager>();
            GameObject temp = GameObject.Find("Transform Icons");
            anim = temp.GetComponent<Animator>();
        }

        #region -- // Event Subscribing / Unsubscribing // --
        private void OnEnable()
        {
            matterStateManager.OnStateSwapped += OnStateSwapped;
        }

        private void OnDisable()
        {
            matterStateManager.OnStateSwapped -= OnStateSwapped;
        }
        #endregion

        /// <summary>
        /// Invoked when the player swaps states.
        /// Displays appropriate UI sprites to signify which state was swapped ot.
        /// </summary>
        /// <param name="state">The state which was swapped to.</param>
        private void OnStateSwapped(StateOfMatterEnum state)
        {
            switch (state)
            {
                case StateOfMatterEnum.DEFAULT:
                    waterIcon.SetActive(false);
                    iceIcon.SetActive(false);
                    steamIcon.SetActive(false);
                    break;
                case StateOfMatterEnum.LIQUID:
                case StateOfMatterEnum.WATERFALL:
                    waterIcon.SetActive(true);
                    anim.SetTrigger("Water");
                    break;
                case StateOfMatterEnum.GAS:
                    steamIcon.SetActive(true);
                    anim.SetTrigger("Steam");
                    break;
                case StateOfMatterEnum.ICE:
                    iceIcon.SetActive(true);
                    anim.SetTrigger("Ice");
                    break;
            }
        }

        //// Update is called once per frame
        //void Update()
        //{
        //    if(matterStateManager.CurrentState == "LIQUID")
        //    {
        //        //Set liquid icon active
        //        //Play liquid icon animation
        //    }

        //}
    }
}
