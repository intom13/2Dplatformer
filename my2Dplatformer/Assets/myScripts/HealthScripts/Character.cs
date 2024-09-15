using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    private readonly float _maxHealth = 100.0f;
    
    public event Action<float> Changed;

    public float MaxHealth => _maxHealth;

    protected void StartHealthEvent(float health)
    {
        Changed?.Invoke(health);
    }
}