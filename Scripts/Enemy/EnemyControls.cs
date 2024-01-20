using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyControls : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Prey _target;
    
    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        transform.right = _target.transform.position - transform.position;
    }

    public void SetTarget(Prey target)
    {
        _target = target;
    }
}
