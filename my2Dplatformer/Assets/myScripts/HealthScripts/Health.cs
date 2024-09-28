using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    protected float HealthValue = 100.0f;

    private readonly float _maxValue = 100.0f;
    private readonly float _minValue = 0f;

    public event Action<float> Changed;

    public float MaxValue => _maxValue;

    public void ApplyDamage(float damageValue)
    {
        HealthValue -= damageValue;

        if (HealthValue < _minValue)
        {
            HealthValue = _minValue;
            Die();
        }

        Changed?.Invoke(HealthValue);
    }

    public void ApplyHeal(float healValue)
    {
        HealthValue += healValue;

        if (HealthValue > _maxValue)
            HealthValue = _maxValue;

        Changed?.Invoke(HealthValue);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
