using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDetector : MonoBehaviour
{
    public event Action<ItemsDetector> Empty;
    public bool IsEmpty => _items.Count <= 0;

    private List<Item> _items = new List<Item>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Item>(out var item))
        {
            _items.Add(item);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Item>(out var item))
        {
            _items.Remove(item);
            item.Delete();

            if (_items.Count == 0)
            {
                Empty?.Invoke(this);
            }
        }
    }
}
