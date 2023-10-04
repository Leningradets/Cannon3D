using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    private void Start()
    {
        Game.Instance.StateChanged += OnGameStateChanged;
    }
    
    private void OnDestroy()
    {
        Game.Instance.StateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState state)
    {
        if(state == GameState.Start)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
