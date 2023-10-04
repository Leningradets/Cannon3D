using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CannonInput), typeof(Cannon))]
public class CannonShooter : MonoBehaviour
{
    [SerializeField] private float _timeBetweenShots;

    private CannonInput _input;
    private Cannon _cannon;


    private float _timeFromLastShot;

    private void Awake()
    {
        _input = GetComponent<CannonInput>();
        _cannon = GetComponent<Cannon>();
    }

    private void Update()
    {
        _timeFromLastShot += Time.deltaTime;

        if (_input.Shoot && _timeFromLastShot >= _timeBetweenShots)
        {
            if(_cannon.TryGetProjectile(out var projectile))
            {
                projectile.Launch(_cannon.BarrelEnd.position, _input.Target);

                _timeFromLastShot = 0;
            }
        }
    }
}
