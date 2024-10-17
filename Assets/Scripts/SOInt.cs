using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOInt", menuName = "SO/Int")]
public class SOInt : ScriptableObject
{
    public event Action<int> OnUpdated;

    public int Value
    {
        get => _value;
        set
        {
            if (_value == value) return;

            _value = value;
            OnUpdated?.Invoke(_value);
        }
    }

    [SerializeField] private int _value;
}
