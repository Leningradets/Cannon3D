using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : Projectile
{
    [SerializeField] private float _force;
    [SerializeField] private float _lifetime;

    private Rigidbody _rigidbody;
    private Transform _transform;

    public override void Launch(Vector3 origin ,Vector3 target)
    {
        transform.position = origin;
        transform.LookAt(target);

        _rigidbody.AddForce((target - origin).normalized * _force, ForceMode.Impulse);
    }

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
        StartCoroutine(DeactivateWithDelay());
        _rigidbody.useGravity = false;
    }

    IEnumerator DeactivateWithDelay()
    {
        yield return new WaitForSeconds(_lifetime);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_rigidbody.useGravity)
            _rigidbody.useGravity = true;
    }
}
