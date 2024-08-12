using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyTemplate;

    private Vector3 _spawnDistance = new Vector2( 1, 0);

    public void Spawn()
    {
        Instantiate(_enemyTemplate, transform.position + _spawnDistance, Quaternion.identity, transform);
    }
}
