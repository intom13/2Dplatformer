using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _prefab;

    private void Start()
    {
        Instantiate(_prefab, transform.position, Quaternion.identity, transform);
    }
}
