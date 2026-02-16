using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] protected LayerMask _layerMask = default;
    [SerializeField] protected int _damage = 1;

    protected void CauseDamage(Collider2D _other)
    {
        if (CanDamage(_other.gameObject))
        {
            if (_other.TryGetComponent(out HealthBehaviour _health))
            {
                _health.TakeDamage(_damage);
            }
        }
    }

    protected bool CanDamage(GameObject _other)
    {
        return (_layerMask.value & (1 << _other.layer)) != 0;
    }
}
