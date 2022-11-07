using UnityEngine;

namespace Asteroids
{
    public class PlayerShooting : UpdatableObject
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private float _nextShotCountdown = 0.0f;
        [SerializeField] private float _shotSpeed = 5.0f;
        // [SerializeField] private ParticleSystem _shootEffect;
        [SerializeField] private float _playerFirerate = 1.0f;
        [SerializeField] private float _playerDamage = 1.0f;

        public override void CustomUpdate()
        {
            if (Input.GetKey(KeyCode.Mouse0) && Time.time > _nextShotCountdown)
            {
                _nextShotCountdown = Time.time + _playerFirerate;
                GameObject bullet = Instantiate(_bullet, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(_bulletSpawnPoint.up * _shotSpeed, ForceMode2D.Impulse);
                var bulletStats = _bullet.GetComponent<BulletController>();
                bulletStats.bulletDamage = _playerDamage;
                bulletStats.canDamagePlayer = false;
                // _shootEffect.Play();
            }
        }
    }
}