using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyTemplate;

    private Vector3 _spawnOffset = new Vector2( 1, 0);

    public void Spawn()
    {
        Instantiate(_enemyTemplate, transform.position + _spawnOffset, Quaternion.identity, transform);
    }
}
