using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] Transform _a = null;
    [SerializeField] Transform _b = null;
    [SerializeField] float _speed = 1f;

    private Vector3 _target = default;

    private void Start()
    {
        _a.parent = null;
        _b.parent = null;

        transform.position = _a.position;
        _target = _b.position;
    }

    private void Update()
    {
        //var _t = Mathf.PingPong(Time.time * _speed, 1f);
        //transform.position = Vector3.Lerp(_a.position, _b.position, _t);
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _target) < 0.001f)
        {
            _target = _target == _a.position ? _b.position : _a.position;
            transform.localScale = new(_target == _a.position ? -1f : 1f, 1, 1);
        }
    }
}
