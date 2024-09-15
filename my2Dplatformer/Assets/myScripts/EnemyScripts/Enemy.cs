using System;

public class Enemy : Character
{
    private float _healthValue = 100.0f;

    private readonly float _maxHealthValue = 100.0f;
    private readonly float _minHealthValue = 0.0f;

    public float MaxValue => _maxHealthValue;

    public void ApplyDamage(float damageValue)
    {
        _healthValue -= damageValue;

        if (_healthValue < _minHealthValue)
        {
            _healthValue = _minHealthValue;
            Die();
        }

        StartHealthEvent(_healthValue);
    }

    public void ApplyHeal(float healValue)
    {
        _healthValue += healValue;

        if (_healthValue > _maxHealthValue)
            _healthValue = _maxHealthValue;

        StartHealthEvent(_healthValue);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
