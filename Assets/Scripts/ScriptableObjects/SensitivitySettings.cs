/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GoofyGhosts
{
    public class SensitivitySettings : MonoBehaviour
    {
        public static SensitivitySettings instance;
        public float sensitivity;

        [SerializeField] private Slider sensSlider;

        private void Awake()
        {
            instance = this;

            sensSlider.value = PlayerPrefs.GetFloat("Sensitivity");
            if (sensSlider.value == 0)
            {
                sensitivity = 1;
                sensSlider.value = 1;
            }
        }

        public void UpdateSensitivity(float value)
        {
            sensitivity = value;
            PlayerPrefs.SetFloat("Sensitivity", value);
        }
    }
}
