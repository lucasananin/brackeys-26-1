using System.Collections.Generic;
using UnityEngine;

public class DamageOnStay : DamageSource
{
    [Header("// ON STAY")]
    [SerializeField] float _damageRate = 1f;

    private List<HealthBehaviour> _victims = new();
    private float _nextDamage = 0;

    private void Update()
    {
        _nextDamage += Time.deltaTime;

        if (_victims.Count == 0) return;

        if (_nextDamage > _damageRate)
        {
            _nextDamage = 0;
            int _count = _victims.Count;

            for (int i = 0; i < _count; i++)
            {
                _victims[i].TakeDamage(gameObject, _damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (CanDamage(_other.gameObject) && _other.TryGetComponent(out HealthBehaviour _health))
        {
            _victims.Add(_health);
        }
    }

    private void OnTriggerExit2D(Collider2D _other)
    {
        if (CanDamage(_other.gameObject) && _other.TryGetComponent(out HealthBehaviour _health))
        {
            _victims.Remove(_health);
        }
    }
}
