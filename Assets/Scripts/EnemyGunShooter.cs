using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunShooter : MonoBehaviour
{
    [SerializeField] private Transform _shotPos;
    [SerializeField] private Transform _target;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _rateOfFire;
    [SerializeField] private float _bulletLifeTime;
    [SerializeField] private AudioClip _shotSound;

    private float _lastShotTime;

    private void Update()
    {
        if (_lastShotTime + _rateOfFire < Time.time &&
            ((Vector2)FindObjectOfType<PlayerMovement>().transform.position -
            (Vector2)transform.position).magnitude < 10)
        {
            Shot();
            _lastShotTime = Time.time;
        }
    }

    private void Shot()
    {
        Bullet bullet = Instantiate(_bulletPrefab, _shotPos.position, Quaternion.identity);
        Vector2 difference = _target.position - _shotPos.position;
        difference.Normalize();
        bullet.Shot(difference);
        bullet.Speed = _bulletSpeed;
        bullet.Lifetime = _bulletLifeTime;
        AudioPlayer.PlaySound(_shotSound);
    }
}
