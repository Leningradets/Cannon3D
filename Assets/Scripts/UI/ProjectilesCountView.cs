using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ProjectilesCountView : MonoBehaviour
{
    [SerializeField] private Cannon _cannon;

    private TMP_Text _tMP_Text;

    private void Awake()
    {
        _tMP_Text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _cannon.ProjectilesCountChanged += OnProjectilesCountChanged;
        OnProjectilesCountChanged(_cannon.ProjectilesCount);
    }
    
    private void OnDisable()
    {
        _cannon.ProjectilesCountChanged -= OnProjectilesCountChanged;
    }

    private void OnProjectilesCountChanged(int count)
    {
        _tMP_Text.text = count.ToString();
        if(count <= 0)
        {
            _tMP_Text.color = Color.red;
        }
        else
        {
            _tMP_Text.color = Color.white;
        }
    }
}
