/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace GoofyGhosts
{
    public class HydrationMeter : MonoBehaviour
    {
        private bool changing;

        /// <summary>
        /// Returns true if the meter is depleted.
        /// </summary>
        public bool isDepleted
        {
            get
            {
                return data.currentValue <= 0;
            }
        }
        /// <summary>
        /// Returns true if the meter is full.
        /// </summary>
        public bool isFull
        {
            get
            {
                return data.currentValue >= data.maxValue;
            }
        }

        public UnityAction OnDepleted;
        public UnityAction OnFilled;

        [SerializeField] private HydrationMeterData data;
        [SerializeField] private HydrationDataChannel hydrationMeterChannel;
        /// <summary>
        /// The current value of the hydration meter.
        /// </summary>
        public float CurrentValue
        {
            get
            {
                return data.currentValue;
            }
        }

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
        /// <summary>
        /// Start decreasing the meter.
        /// </summary>
        public void StartDecrease()
        {
            // Don't bother decreasing if already depleted.
            if (isDepleted)
                return;

            changing = true;
            StartCoroutine(Decrease());
        }

        /// <summary>
        /// Decreases the hydration meter by a value.
        /// </summary>
        /// <param name="value">The value to decrease the hydration meter by.</param>
        public void DecreaseBy(float value)
        {
            data.currentValue -= value;
            hydrationMeterChannel.RaiseEvent(data);
        }

        /// <summary>
        /// Start increasing the meter.
        /// </summary>
        public void StartIncrease()
        {
            // Don't bother increasing if already full.
            if (isFull)
                return;

            changing = true;
            StartCoroutine(Increase());
        }

        /// <summary>
        /// Stop increasing or decreasing the meter.
        /// </summary>
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

                // If we ran out of hydration,
                // invoke the OnDepleted event 
                // and stop depleting.
                if (isDepleted)
                {
                    changing = false;
                    OnDepleted?.Invoke();
                }

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

                // If the meter is full,
                // invoke the OnFilled event and
                // stop filling.
                if (isFull)
                {
                    changing = false;
                    OnFilled?.Invoke();
                }

                yield return null;
            }
        }
        #endregion
    }
}