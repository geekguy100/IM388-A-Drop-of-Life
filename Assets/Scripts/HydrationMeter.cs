/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;
using System.Collections;

namespace GoofyGhosts
{
    public class HydrationMeter : MonoBehaviour
    {
        private bool changing;

        [SerializeField] private HydrationMeterData data;
        [SerializeField] private HydrationDataChannel hydrationMeterChannel;

        [Tooltip("Rate of decrease per second.")]
        [SerializeField] private float decreaseRate;

        [Tooltip("Rate of increase per second.")]
        [SerializeField] private float increaseRate;

        private void Start()
        {
            data.currentValue = data.maxValue;
            hydrationMeterChannel.RaiseEvent(data);
        }

        #region -- // Public Methods // --
        public void StartDecrease()
        {
            changing = true;
            StartCoroutine(Decrease());
        }

        public void StartIncrease()
        {
            changing = true;
            StartCoroutine(Increase());
        }

        public void StopChange()
        {
            changing = false;
        }
        #endregion

        #region -- // Private Coroutines // --
        private IEnumerator Decrease()
        {
            while(changing)
            {
                data.currentValue -= Time.deltaTime * decreaseRate;
                data.currentValue = Mathf.Clamp(data.currentValue, 0, data.maxValue);

                hydrationMeterChannel.RaiseEvent(data);
                yield return null;
            }
        }

        private IEnumerator Increase()
        {
            while (changing)
            {
                data.currentValue += Time.deltaTime * increaseRate;
                data.currentValue = Mathf.Clamp(data.currentValue, 0, data.maxValue);

                hydrationMeterChannel.RaiseEvent(data);
                yield return null;
            }
        }
        #endregion
    }
}