using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class UI_Animation : MonoBehaviour
    {

        public GameObject waterIcon, iceIcon, steamIcon;

        public Animator anim;

        private MatterStateManager matterStateManager;

        void Awake()
        {
            matterStateManager = GetComponent<MatterStateManager>();
            anim = GetComponent<Animator>();
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
                    // PUT CODE HERE FOR DEFAULT STATE.
                    break;
                case StateOfMatterEnum.LIQUID:
                case StateOfMatterEnum.WATERFALL:
                    // PUT CODE HERE FOR LIQUID STATE.
                    break;
                case StateOfMatterEnum.GAS:
                    // PUT CODE HERE FOR GAS STATE.
                    break;
                case StateOfMatterEnum.ICE:
                    // PUT CODE HERE FOR ICE/SOLID STATE.
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
