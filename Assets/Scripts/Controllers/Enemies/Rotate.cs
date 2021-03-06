using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class Rotate : MonoBehaviour
    {

        public float rotateSpeed;

        void Update()
        {
            transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.deltaTime);
        }
    }
}
