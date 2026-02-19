using UnityEngine;
using UnityEngine.Events;

public class DamageSource : MonoBehaviour
{
    [SerializeField] protected LayerMask _layerMask = default;
    [SerializeField] protected int _damage = 1;

    public event UnityAction<Collider2D> OnDamage = null;

    protected void CauseDamage(Collider2D _other)
    {
        if (CanDamage(_other.gameObject))
        {
            if (_other.TryGetComponent(out HealthBehaviour _health))
            {
                _health.TakeDamage(gameObject, _damage);
                OnDamage?.Invoke(_other);
            }
        }
    }

    protected bool CanDamage(GameObject _other)
    {
        return (_layerMask.value & (1 << _other.layer)) != 0;
    }
}
