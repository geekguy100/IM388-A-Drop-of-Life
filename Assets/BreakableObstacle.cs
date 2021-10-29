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
        public void Break()
        {
            print("BREAK");
            Destroy(gameObject);
        }
    }
}
