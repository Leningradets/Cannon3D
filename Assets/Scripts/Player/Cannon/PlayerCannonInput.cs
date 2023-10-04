using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannonInput : CannonInput
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance;

    private float _distanceFromLastRaycast;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _distanceFromLastRaycast = _maxDistance;
    }

    private void Update()
    {
        HandleTarget();
        _shoot = Input.GetMouseButton(0);
    }

    private void HandleTarget()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, _maxDistance))
        {
            _target = hit.point;
            _distanceFromLastRaycast = hit.distance;
        }
        else
        {
            _target = transform.position + ray.direction * _distanceFromLastRaycast;
        }
    }
}
