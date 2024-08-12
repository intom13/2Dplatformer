using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _playerDamage;
    [SerializeField] private float _playerAttackRadius;
    [SerializeField] private float _punchForce;
    [SerializeField] private float _punchVerticalForce;

    private Collider2D[] _nearbyColliders;

    public void Punch()
    {
        _nearbyColliders = Physics2D.OverlapCircleAll(transform.position, _playerAttackRadius);

        foreach(var collider in _nearbyColliders)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                Vector2 punchDirection = enemy.transform.position - transform.position;

                if (enemy.TryGetComponent(out Rigidbody2D enemyRigidbody))
                    enemyRigidbody.AddForce(Vector2.up * _punchVerticalForce + punchDirection.normalized * _punchForce, ForceMode2D.Impulse);

                enemy.ApplyDamage(_playerDamage);
            }
        }
    }
}
