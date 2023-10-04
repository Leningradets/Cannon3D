using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : StateTransitionHandler
{
    [SerializeField] private Cannon _cannon;
    [SerializeField] private Timer _timer;

    private List<ItemsDetector> _detectors;

    private void OnEnable()
    {
        _cannon.ProjectilesCountChanged += OnProjectilesCountChanged;
        _timer.RanOut += OnTimerRanOut;
    }

    private void OnDisable()
    {
        _cannon.ProjectilesCountChanged -= OnProjectilesCountChanged;
        _timer.RanOut -= OnTimerRanOut;
    }

    private void OnProjectilesCountChanged(int count)
    {
        if (count <= 0)
        {
            _timer.StartCount();
        }
        else
        {
            _timer.Stop();
        }
    }

    private void OnTimerRanOut()
    {
        RaisePing();
    }
}
