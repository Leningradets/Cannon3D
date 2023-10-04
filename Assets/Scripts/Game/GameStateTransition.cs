using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameStateTransition
{
    public event Action<GameStateTransition, GameState> NeedTransit;

    public GameState From => _from;

    [SerializeField] private StateTransitionHandler _transitionHandler;
    [SerializeField] private GameState _from;
    [SerializeField] private GameState _to;

    public void Enable()
    {
        _transitionHandler.Ping += OnHadlerPing;
    }

    public void Disable()
    {
        _transitionHandler.Ping -= OnHadlerPing;
    }

    private void OnHadlerPing()
    {
        NeedTransit.Invoke(this, _to);
    }
}
