using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] Transform _a = null;
    [SerializeField] Transform _b = null;
    [SerializeField] float _speed = 1f;

    private void Start()
    {
        _a.parent = null;
        _b.parent = null;
    }

    private void Update()
    {
        var _t = Mathf.PingPong(Time.time * _speed, 1f);
        transform.position = Vector3.Lerp(_a.position, _b.position, _t);
    }
}
