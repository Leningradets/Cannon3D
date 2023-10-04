using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public event Action<GameState> StateChanged;

    [SerializeField] private GameStateTransition[] _transitions;

    private List<GameStateTransition> _activeTrasitions = new List<GameStateTransition>();

    private GameState _firstState = GameState.Start;

    private GameState _currentState;
    public GameState CurrentState => _currentState;

    private void Start()
    {
        _currentState = _firstState;
        GetActiveTransitions();
    }

    private void GetActiveTransitions()
    {
        _activeTrasitions.Clear();

        foreach (var transition in _transitions)
        {
            if (transition.From == _currentState)
            {
                _activeTrasitions.Add(transition);
                transition.NeedTransit += OnNeedTransit;
                transition.Enable();
            }
            else
            {
                transition.Disable();
            }
        }
    }

    private void OnNeedTransit(GameStateTransition transition, GameState state)
    {
        _currentState = state;
        StateChanged?.Invoke(_currentState);

        transition.NeedTransit -= OnNeedTransit;
        GetActiveTransitions();
    }
}
