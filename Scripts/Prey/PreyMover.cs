using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PreyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _walkPointsParent;
    [SerializeField] private int _startingPointIndex;

    private int _targetPointIndex;
    private List<Transform> _walkPoints;
    
    private Transform TargetPoint => _walkPoints[_targetPointIndex];

    private void Start()
    {
        _walkPoints = _walkPointsParent.GetComponentsInChildren<Transform>().ToList();
        _walkPoints.RemoveAt(0);
        transform.position = _walkPoints[_startingPointIndex].position;
        _targetPointIndex = _startingPointIndex;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPoint.position, _speed * Time.deltaTime);

        if (transform.position == TargetPoint.position)
        {
            if (_targetPointIndex == _walkPoints.Count - 1)
                _targetPointIndex = 0;
            else
                _targetPointIndex++;
        }
    }
}
