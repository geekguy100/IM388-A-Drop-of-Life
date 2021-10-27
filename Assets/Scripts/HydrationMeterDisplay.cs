/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace GoofyGhosts
{
    [RequireComponent(typeof(Slider))]
    public class HydrationMeterDisplay : MonoBehaviour
    {
        [Tooltip("Channel used to receive hydration meter change updates from.")]
        [SerializeField] private HydrationDataChannel hydrationMeterChannel;

        private bool initialized;

        private Slider slider;

        #region -- // Init // --
        private void Awake()
        {
            slider = GetComponent<Slider>();
            initialized = false;
        }

        private void OnEnable()
        {
            hydrationMeterChannel.OnEventRaised += UpdateHydrationBar;
        }

        private void OnDisable()
        {
            hydrationMeterChannel.OnEventRaised -= UpdateHydrationBar;
        }
        #endregion

        public void UpdateHydrationBar(HydrationMeterData data)
        {
            if (!initialized)
            {
                slider.maxValue = data.maxValue;
                slider.minValue = 0;
                slider.value = data.maxValue;
                initialized = true;
            }
            else
            {
                //StopAllCoroutines();
                StartCoroutine(LerpHydrationBar(data.currentValue));
            }
        }

        /// <summary>
        /// Lerps the hydration bar to a new value.
        /// </summary>
        /// <param name="newValue">The new value of the hydration bar.</param>
        private IEnumerator LerpHydrationBar(float newValue)
        {
            const float LERP_TIME = 0.3f;
            float currentTime = 0f;

            float currentValue = slider.value;

            while (currentTime < LERP_TIME)
            {
                currentTime += Time.deltaTime;

                slider.value = Mathf.Lerp(currentValue, newValue, currentTime / LERP_TIME);

                yield return null;
            }
        }
    }

    [System.Serializable]
    public struct HydrationMeterData
    {
        public float maxValue;
        public float currentValue;

        HydrationMeterData(float maxValue, float currentValue)
        {
            this.maxValue = maxValue;
            this.currentValue = currentValue;
        }
    }
}
