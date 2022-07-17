using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField] private StartCharacteristics _startCharacteristics;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shotPosition;
    [SerializeField] private AudioClip _shotSound;
    [SerializeField] private Transform _audioListener;

    private float _rateOfFire;
    private float _defaultBulletSpeed;
    private float _defaultBulletRange;

    private float _lastFireTime;

    public bool IsImmovable { get; set; }

    private void Awake()
    {
        _defaultBulletRange = _startCharacteristics.BulletRange;
        _defaultBulletSpeed = _startCharacteristics.BulletSpeed;
        _rateOfFire = _startCharacteristics.RateOfFire;

        _bulletPrefab.Speed = _defaultBulletSpeed;
        _bulletPrefab.Lifetime = _defaultBulletRange;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && _lastFireTime + _rateOfFire < Time.time)
        {
            Shot();
            _lastFireTime = Time.time;
        }
    }

    private void Shot()
    {
        if (!IsImmovable)
        {
            Bullet bullet = Instantiate(_bulletPrefab, _shotPosition.position, Quaternion.identity);

            Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();

            bullet.Shot(difference);
            AudioPlayer.PlaySound(_shotSound);
        }
    }

    public void Shot(Bullet bulletPrefab)
    {
        if (!IsImmovable)
        {
            Bullet bullet = Instantiate(bulletPrefab, _shotPosition.position, Quaternion.identity);

            Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();

            bullet.Shot(difference);
            AudioPlayer.PlaySound(_shotSound);
        }
    }

    public void RateOfFireUp()
    {
        _rateOfFire -= 0.075f;
    }

    public void BulletSpeedUp()
    {
        _bulletPrefab.Speed += 2f;
    }

    public void BulletRangeUp()
    {
        _bulletPrefab.Lifetime += 0.1f;
    }

}
