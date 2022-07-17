using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private StartCharacteristics _startCharacteristics;
    private float _speed;
    private float _jumpStrength;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private AudioClip _jumpSound;

    private float _moving;
    private bool _isJumping;

    public bool IsGrounded { get; set; }
    public bool IsImmovable { get; set; }

    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _speed = _startCharacteristics.Speed;
        _jumpStrength = _startCharacteristics.JumpStrength;
    }
    private void Update()
    {
        _moving = Input.GetAxis("Horizontal");
        _isJumping = Input.GetKey(KeyCode.Space);
        CheckGround();
    }

    private void FixedUpdate()
    {
        Move();
        if (_isJumping && IsGrounded)
        {
            Jump();
        }
    }

    private void Move()
    {
        if (!IsImmovable)
        {
            _rigidbody.AddForce(new Vector2(_moving, 0) * _speed);
        }
    }

    public void Jump()
    {
        if (!IsImmovable)
        {
            _rigidbody.AddForce(Vector2.up * _jumpStrength);
            AudioPlayer.PlaySound(_jumpSound);
            _isJumping = false;
            IsGrounded = false;
        }
    }

    private void CheckGround()
    {
        IsGrounded = Physics2D.OverlapCircle(_groundChecker.position, 0.1f, _layer);
    }

    public void SpeedUp()
    {
        _speed += 2f;
    }

    public void JumpUp()
    {
        _jumpStrength += 33f;
    }
}
