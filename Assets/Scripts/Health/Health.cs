/*****************************************************************************
// File Name :         Health.cs
// Author :            Kyle Grenier
// Creation Date :     #CREATIONDATE#
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    /// <summary>
    /// Action raised when the health is modified.
    /// </summary>
    [SerializeField] private UnityEvent<HealthData> OnHealthChange;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        OnHealthChange?.Invoke(GetHealthData());
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        OnHealthChange?.Invoke(GetHealthData());

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private HealthData GetHealthData()
    {
        return new HealthData(maxHealth, currentHealth);
    }
}

/// <summary>
/// Struct to hold health data.
/// </summary>
public struct HealthData
{
    public float maxHealth;
    public float currentHealth;

    public HealthData(float maxHealth, float currentHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
    }
}