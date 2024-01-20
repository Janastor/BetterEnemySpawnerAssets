using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    public void SpawnEnemy(Prey target)
    {
        Enemy spawned = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        spawned.Init(transform.rotation, target);
    }
}