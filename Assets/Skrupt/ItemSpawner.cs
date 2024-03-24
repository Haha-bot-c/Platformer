using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Item _itemPrefab;
    [SerializeField] private Transform _pathPoints;
    [SerializeField] private float _spawnInterval = 2.0f;

    private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new Transform[_pathPoints.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
            _spawnPoints[i] = _pathPoints.GetChild(i);

        StartCoroutine(SpawnItems());
    }

    private IEnumerator SpawnItems()
    {
        WaitForSeconds wait = new(_spawnInterval);

        while (true)
        {
            int randomIndex = Random.Range(0, _spawnPoints.Length);
            Transform spawnPoint = _spawnPoints[randomIndex];

            Item newItem = Instantiate(_itemPrefab, spawnPoint.position, spawnPoint.rotation);

            yield return wait;
        }
    }
}
