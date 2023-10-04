using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CannonInput))]
public class CannonController : MonoBehaviour
{
    [SerializeField] private float _rotationLerpStrenght;

    private CannonInput _input;
    private Transform _transform;

    private void Awake()
    {
        _input = GetComponent<CannonInput>();
        _transform = transform;
    }

    private void Update()
    {
        var targetDirection = (_input.Target - _transform.position).normalized;

        transform.forward = Vector3.Lerp(transform.forward, targetDirection, _rotationLerpStrenght);
    }
}
