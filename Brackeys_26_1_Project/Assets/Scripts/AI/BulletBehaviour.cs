using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb = null;
    [SerializeField] DamageSource _damageSource = null;

    private void OnEnable()
    {
        _damageSource.OnDamage += _damageSource_OnDamage;
    }

    private void OnDisable()
    {
        _damageSource.OnDamage -= _damageSource_OnDamage;
    }

    public void Shoot(Vector2 _velocity)
    {
        _rb.linearVelocity = _velocity;
    }

    private void _damageSource_OnDamage(Collider2D arg0)
    {
        Destroy(gameObject);
    }
}
