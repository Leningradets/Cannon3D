using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelCompliteHandler : StateTransitionHandler
{
    private List<ItemsDetector> _detectors;

    private void Awake()
    {
        _detectors = FindObjectsOfType<ItemsDetector>().ToList();

        foreach (var detector in _detectors)
        {
            if (detector.IsEmpty)
            {
                continue;
            }

            detector.Empty += OnItemDetecorEmpty;
        }

        _detectors.RemoveAll(detector => detector.IsEmpty);
    }

    private void OnItemDetecorEmpty(ItemsDetector detector)
    {
        detector.Empty -= OnItemDetecorEmpty;
        _detectors.Remove(detector);

        if(_detectors.Count == 0)
        {
            RaisePing();
        }
    }
}
