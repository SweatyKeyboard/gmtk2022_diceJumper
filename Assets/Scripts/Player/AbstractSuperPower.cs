using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SuperPower")]
public class AbstractSuperPower : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _maxValue;

    private float _value;

    public float Value
    {
        get => _value;
        set => _value = value;
    }
    public string Name => _name;

    public void ResetValue()
    {
        _value = _maxValue;
    }


}
