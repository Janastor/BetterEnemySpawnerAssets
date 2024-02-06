using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Prey _target;

    private EnemySpawnPoint[] _spawnPoints;
    private bool _isWorking = true;
    private Coroutine _spawnLoopCoroutine;
    
    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<EnemySpawnPoint>();
        _spawnLoopCoroutine = StartCoroutine(SpawnEnemyLoop());
    }
    
    private IEnumerator SpawnEnemyLoop()
    {
        float spawnTimer = 0;
        
        while (_isWorking)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= _spawnDelay)
            {
                SpawnEnemyAtPoint(Random.Range(0, _spawnPoints.Length));
                spawnTimer = 0;
            }

            yield return null;
        }
    }

    private void SpawnEnemyAtPoint(int index)
    {
        _spawnPoints[index].SpawnEnemy(_target);
    }
}
