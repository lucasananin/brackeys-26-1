using UnityEngine;

public class PackageHolder : MonoBehaviour
{
    [SerializeField] Rigidbody2D _prefab = null;
    [SerializeField] Transform _point = null;
    [SerializeField] int _amount = 1;
    [Space]
    [SerializeField] Vector2 _xForce = new(3f, 5f);
    [SerializeField] Vector2 _yForce = new(3f, 5f);
    [SerializeField] float _torque = 5f;

    public void Drop(HealthBehaviour _health)
    {
        if (_amount <= 0) return;

        _amount--;
        var _instance = Instantiate(_prefab, _point.position, Quaternion.identity);

        float _xDirection = _health.LastDamageSource.transform.position.x > _point.position.x ? -1f : 1f;
        float _x = Random.Range(_xForce.x, _xForce.y) * -_xDirection;
        float _y = Random.Range(_yForce.x, _yForce.y);
        _instance.AddForce(new(_x, _y), ForceMode2D.Impulse);
        _instance.AddTorque(_torque * _xDirection, ForceMode2D.Impulse);
    }

    internal void IncreaseAmount()
    {
        _amount++;
    }
}
