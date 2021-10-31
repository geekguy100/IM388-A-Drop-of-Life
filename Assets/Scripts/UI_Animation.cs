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

        // Update is called once per frame
        void Update()
        {
            if(matterStateManager.CurrentState == "LIQUID")
            {
                //Set liquid icon active
                //Play liquid icon animation
            }

        }
    }
}
