using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] BulletBehaviour _bullet = null;
    [SerializeField] Transform _muzzle = null;
    [SerializeField] Vector2 _shootDirection = default;
    [SerializeField] float _speed = 2f;
    [SerializeField] float _fireRate = 2f;

    [Header("// RUNTIME")]
    [SerializeField] float _nextFire = 0f;

    private void Update()
    {
        _nextFire += Time.deltaTime;

        if (_nextFire > _fireRate)
        {
            _nextFire = 0;
            var _instance = Instantiate(_bullet, _muzzle.position, Quaternion.identity);
            _instance.Shoot(_shootDirection * _speed);
        }
    }
}
