using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public event Action<int> ProjectilesCountChanged;

    [SerializeField] private Transform _barrelEnd;
    [SerializeField] private Projectile _projectileTemplate;
    [SerializeField] private Transform _projectilesContainer;
    [SerializeField] private int _projectilesCount;

    private PoolMono<Projectile> _projectilesPool;

    public Transform BarrelEnd => _barrelEnd;

    public int ProjectilesCount => _projectilesCount;

    private void Awake()
    {
        _projectilesPool = new PoolMono<Projectile>(_projectileTemplate, _projectilesCount, true, _projectilesContainer);
    }

    public bool TryGetProjectile(out Projectile projectile)
    {
        if(_projectilesCount > 0)
        {
            _projectilesCount--;
            ProjectilesCountChanged?.Invoke(_projectilesCount);
            return _projectilesPool.TryGetFreeElement(out projectile);
        }
        else
        {
            projectile = null;
            return false;
        }
    }
}
