using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float _value = 100.0f;

    private readonly float _maxValue = 100.0f;
    private readonly float _minValue = 0.0f;

    public event Action<float> Changed;

    public float MaxValue => _maxValue;

    public void ApplyDamage(float damageValue)
    {
        _value -= damageValue;

        if(_value < _minValue)
        {
            _value = _minValue;
            Die();
        }

        Changed?.Invoke(_value);
    }

    public void ApplyHeal(float healValue)
    {
        _value += healValue;

        if (_value > _maxValue)
            _value = _maxValue;

        Changed?.Invoke(_value);
    }

    protected virtual void Die() { }
}