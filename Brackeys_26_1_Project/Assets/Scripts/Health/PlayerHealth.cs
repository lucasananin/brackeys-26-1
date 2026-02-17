using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : HealthBehaviour
{
    [Header("// PLAYER")]
    //[SerializeField] float _timeRate = 1f;
    //[SerializeField] int _decreaseRate = 1;
    [SerializeField] UnityEvent _onPlayerDead = null;

    //private float _timer = 0f;

    public static event UnityAction OnPlayerHurt = null;
    public static event UnityAction OnPlayerDead = null;

    protected override void Awake()
    {
        RestoreAllHealth();
    }

    //private void LateUpdate()
    //{
    //    _timer += Time.deltaTime;

    //    if (_timer > _timeRate)
    //    {
    //        _timer = 0;
    //        TakeDamage(_decreaseRate);
    //    }
    //}

    protected override void OnDamageTaken_()
    {
        base.OnDamageTaken_();
        RestoreAllHealth();
        OnPlayerHurt?.Invoke();
    }

    protected override void OnDead_()
    {
        base.OnDead_();
        gameObject.SetActive(false);
        OnPlayerDead?.Invoke();
        _onPlayerDead?.Invoke();
    }

    internal void SetInvincibility(bool _value)
    {
        _isInvincible = _value;
    }

    //public void UpdateMaxHealth(int _health)
    //{
    //    _maxHealth += _health;

    //    if(_currentHealth > _maxHealth)
    //        _currentHealth = _maxHealth;
    //}
}
