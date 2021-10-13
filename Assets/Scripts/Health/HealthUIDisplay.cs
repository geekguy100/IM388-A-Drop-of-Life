/*****************************************************************************
// File Name :         HealthUIDisplay.cs
// Author :            Kyle Grenier
// Creation Date :     10/1/2021
//
// Brief Description : Displays health data on UI.
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class HealthUIDisplay : MonoBehaviour
{
    private Slider healthSlider;
    private bool initialized;

    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
        initialized = false;
    }

    public void UpdateHealthBar(HealthData data)
    {
        if (!initialized)
        {
            healthSlider.maxValue = data.maxHealth;
            healthSlider.minValue = 0;
            healthSlider.value = data.maxHealth;
            initialized = true;
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(LerpHealthBar(data.currentHealth));
        }
    }

    // The previous value of the health bar.
    private float previousValue = -1;
    private IEnumerator LerpHealthBar(float targetValue)
    {
        const float LERP_TIME = 0.1f;
        float currentTime = 0f;

        float initialValue;

        // Using a 'previousValue' so 
        // when health changes before finishing lerping,
        // the initialValue will be set to the previous value
        // and lerp from there.
        if (previousValue != -1)
        {
            initialValue = previousValue;
        }
        else
        {
            initialValue = healthSlider.value;
        }

        previousValue = targetValue;

        while(currentTime < LERP_TIME)
        {
            healthSlider.value = Mathf.Lerp(initialValue, targetValue, currentTime / LERP_TIME);
            currentTime += Time.deltaTime;

            yield return null;
        }
    }
}