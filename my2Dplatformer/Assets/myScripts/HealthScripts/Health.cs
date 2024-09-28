using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _healthValue = 100.0f;

    private readonly float _maxValue = 100.0f;
    private readonly float _minValue = 0f;

    public event Action<float> Changed;

    public float MaxValue => _maxValue;

    public void ApplyDamage(float damageValue)
    {
        _healthValue -= damageValue;

        if (_healthValue < _minValue)
        {
            _healthValue = _minValue;
            Die();
        }

        Changed?.Invoke(_healthValue);
    }

    public void ApplyHeal(float healValue)
    {
        _healthValue += healValue;

        if (_healthValue > _maxValue)
            _healthValue = _maxValue;

        Changed?.Invoke(_healthValue);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
