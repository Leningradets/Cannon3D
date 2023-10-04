using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class PreFailedTimer : MonoBehaviour
{
    public event Action RanOut;

    private Timer _timer;

    private void OnEnable()
    {
        _timer = GetComponent<Timer>();

        _timer.StartCount();
        _timer.RanOut += OnTimerRanOut;
    }

    private void OnTimerRanOut()
    {
        _timer.RanOut -= OnTimerRanOut;
        RanOut?.Invoke();
        gameObject.SetActive(false);
    }
}
