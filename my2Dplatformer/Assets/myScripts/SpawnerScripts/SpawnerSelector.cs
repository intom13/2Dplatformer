using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSelector : MonoBehaviour
{
    [SerializeField] private float _spawnerCooldown;

    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    private WaitForSeconds _spawnerRechargeTime;
    private bool _isSpawnerEnable = true;

    private void Start()
    {
        _spawnerRechargeTime = new WaitForSeconds(_spawnerCooldown);

        StartCoroutine(SelectionCycle());
    }

    private IEnumerator SelectionCycle()
    {
        while (_isSpawnerEnable)
        {
            int chosenSpawnerNumber = Random.Range(0, _spawnPoints.Count);

            SpawnLaunch(_spawnPoints[chosenSpawnerNumber]);

            yield return _spawnerRechargeTime;
        }
    }

    private void SpawnLaunch(Transform spawnPoint)
    {
        if (spawnPoint.TryGetComponent(out EnemySpawner spawner))
            spawner.Spawn();
    }
}
