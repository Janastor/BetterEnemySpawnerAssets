using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Prey _target;

    private EnemySpawnPoint[] _spawnPoints;
    private float _spawnTimer;
    
    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<EnemySpawnPoint>();
    }
    
    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _spawnDelay)
        {
            SpawnEnemyAtPoint(Random.Range(0, _spawnPoints.Length));
            _spawnTimer = 0;
        }
    }

    private void SpawnEnemyAtPoint(int index)
    {
        _spawnPoints[index].SpawnEnemy(_target);
    }
}
