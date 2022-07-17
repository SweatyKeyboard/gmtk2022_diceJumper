using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Color _activatedColor;
    [SerializeField] private AudioClip _activateSound;
    private Transform _player;
    private SpriteRenderer _renderer;
    private bool _isReached = false;

    public event System.Action OnReached;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _player = FindObjectOfType<PlayerMovement>().transform;
    }
    private void Update()
    {
        if (_player.position.x >= transform.position.x &&
            _player.position.y >= transform.position.y - _player.lossyScale.y &&
            !_isReached)
        {
            Activate();
        }
    }

    private void Activate()
    {
        _renderer.color = _activatedColor;
        OnReached?.Invoke();
        _isReached = true;
        AudioPlayer.PlaySound(_activateSound);
    }
}
