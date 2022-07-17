using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifetime;
    private Rigidbody2D _rigidbody;

    private float _timer = 0f;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public float Lifetime
    {
        get => _lifetime;
        set => _lifetime = value;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _lifetime)
            Destroy(gameObject);
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Shot(Vector2 angle)
    {
        _rigidbody.velocity = angle * _speed;
    }
}
