using System;
using UnityEngine;

public class Player : HealthBehaviour
{
    [SerializeField] private float _maxPlayerHealth;

    private float _playerHealth;

    public event Action OnGameFinished;

    private void Start()
    {
        _playerHealth = _maxPlayerHealth;
    }

    public void ApplyDamage(float damage)
    {
        _playerHealth -= damage;

        if (_playerHealth <= 0)
            Die();
    }

    public void ApplyHeal(float healValue)
    {
        if(_maxPlayerHealth - _playerHealth >= healValue)
            _playerHealth += healValue;
        else
            _playerHealth = _maxPlayerHealth;
    }

    override public void Die()
    {
        OnGameFinished?.Invoke();
    }
}
