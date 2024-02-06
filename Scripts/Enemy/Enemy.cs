using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]

public class Enemy : MonoBehaviour
{
    private Prey _prey;
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Prey prey))
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void Init(Quaternion rotation, Prey target)
    {
        transform.rotation = rotation;
        _enemyMover.SetTarget(target);
    }
}
