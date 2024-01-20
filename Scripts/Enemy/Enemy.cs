using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyControls))]

public class Enemy : MonoBehaviour
{
    private Prey _prey;
    private EnemyControls _enemyControls;

    private void Awake()
    {
        _enemyControls = GetComponent<EnemyControls>();
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
        _enemyControls.SetTarget(target);
    }
}
