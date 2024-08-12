using UnityEngine;

public class Enemy : HealthBehaviour
{
    [SerializeField] private float _enemyHealth;

    public void ApplyDamage(float damage)
    {
        _enemyHealth -= damage;

        if (_enemyHealth <= 0)
            Die();
    }
}
