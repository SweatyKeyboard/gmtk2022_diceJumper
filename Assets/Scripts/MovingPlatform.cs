using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Direction _direction;
    [SerializeField] private float _pathLength;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isInversedFromStart;

    private Rigidbody2D _rigidBody;
    private float _timeElapsed;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        if (_direction == Direction.Vertical)
        {
            _rigidBody.velocity = Vector2.up * _speed;
        }
        else
        {
            _rigidBody.velocity = Vector2.right * _speed;
        }

        if (_isInversedFromStart)
        {
            _rigidBody.velocity *= -1;
        }
    }
    private void FixedUpdate()
    {
        if (_timeElapsed + _pathLength < Time.time)
        {
            _rigidBody.velocity *= -1;
            _timeElapsed = Time.time;
        }
    }
}

public enum Direction
{
    Vertical,
    Horizontal
}
