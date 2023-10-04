using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateTransitionHandler : MonoBehaviour
{
    public event Action Ping;

    protected void RaisePing()
    {
        Ping?.Invoke();
    }
}
