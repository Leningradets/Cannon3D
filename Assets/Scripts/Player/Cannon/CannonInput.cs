using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonInput : MonoBehaviour
{
    protected Vector3 _target;
    protected bool _shoot;

    public Vector3 Target => _target;
    public bool Shoot => _shoot;
}
