using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Characteristics")]
public class StartCharacteristics : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpStrength;
    [SerializeField] private float _rateOfFire;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletRange;

    public float Speed => _speed;
    public float JumpStrength => _jumpStrength;
    public float RateOfFire => _rateOfFire;
    public float BulletSpeed => _bulletSpeed;
    public float BulletRange => _bulletRange;
}
