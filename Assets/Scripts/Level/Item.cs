using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float _deleteDuration = 3;

    public void Delete()
    {
        Destroy(this.gameObject, _deleteDuration);
    }
}
