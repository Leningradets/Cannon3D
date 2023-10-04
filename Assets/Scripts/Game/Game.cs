using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameStateMachine))]
public class Game : MonoBehaviour
{
    public static Game Instance;

    public event Action<GameState> StateChanged;
    public GameState CurrentState => _stateMachine.CurrentState;

    private GameStateMachine _stateMachine;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        _stateMachine = GetComponent<GameStateMachine>();
    }

    private void OnEnable()
    {
        _stateMachine.StateChanged += OnStateChanged;
    }
    
    private void OnDisable()
    {
        _stateMachine.StateChanged -= OnStateChanged;
    }

    private void OnStateChanged(GameState state)
    {
        StateChanged?.Invoke(state);
    }
}

public enum GameState
{
    None,
    Start,
    Gameplay,
    LevelComplete,
    PreFailed,
    Failed
}