using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _punchForce;
    [SerializeField] private float _punchVerticalForce;
    [SerializeField] private LayerMask _enemyLayer;

    private Collider2D[] _nearbyColliders;

    public void Punch()
    {
        _nearbyColliders = Physics2D.OverlapCircleAll(transform.position, _attackRadius, _enemyLayer);

        foreach(var collider in _nearbyColliders)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                Vector2 punchDirection = enemy.transform.position - transform.position;

                if (enemy.TryGetComponent(out Rigidbody2D enemyRigidbody))
                    enemyRigidbody.AddForce(Vector2.up * _punchVerticalForce + punchDirection.normalized * _punchForce, ForceMode2D.Impulse);

                enemy.ApplyDamage(_damage);
            }
        }
    }
}
