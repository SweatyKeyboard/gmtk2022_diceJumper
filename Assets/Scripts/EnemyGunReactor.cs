using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunReactor : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    [SerializeField] private GameObject _particlesHit;
    [SerializeField] private GameObject _particlesDestory;
    [SerializeField] private AudioClip _hitSound;
    private int _hp;

    public event Action OnDestroyGun;

    private void Awake()
    {
        _hp = _maxHP;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _hp--;
            CheckIfDead();
            Instantiate(_particlesHit, collision.transform.position, Quaternion.identity);
            AudioPlayer.PlaySound(_hitSound);
        }
    }

    private void CheckIfDead()
    {
        if (_hp <= 0)
        {
            Instantiate(_particlesDestory, transform.position, Quaternion.identity);
            OnDestroyGun?.Invoke();
        }
    }
}
