using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackTimeout;
    [SerializeField] private float _punchForce;
    [SerializeField] private LayerMask _playerLayer;

    private Collider2D[] _nearbyColliders;

    private WaitForSeconds _timeBetweenPunch;

    private void Start()
    {
        _timeBetweenPunch = new WaitForSeconds(_attackTimeout);
    }

    public IEnumerator Attacking()
    {
        while (true)
        {
            Punch();

            yield return _timeBetweenPunch;
        }
    }

    private void Punch()
    {
        _nearbyColliders = Physics2D.OverlapCircleAll(transform.position, _attackRadius, _playerLayer);

        foreach (var collider in _nearbyColliders)
        {
            if (collider.TryGetComponent(out Health playerHealth))
            {
                Vector2 punchDirection = playerHealth.transform.position - transform.position;

                if (playerHealth.TryGetComponent(out Rigidbody2D playerRigidbody))
                    playerRigidbody.AddForce(punchDirection.normalized * _punchForce, ForceMode2D.Impulse);

                playerHealth.ApplyDamage(_damage);
            }
        }
    }
}
