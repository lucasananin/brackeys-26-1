using UnityEngine;

public class StateController : MonoBehaviour
{
    [Header("// DEBUG")]
    [SerializeField] protected string _currentStateName = null;

    protected StateMachine _machine = null;
    private float _deltaTime = 0;

    public float DeltaTime { get => _deltaTime; }

    protected virtual void Start()
    {
        _machine = new StateMachine();
    }

    protected virtual void Update()
    {
        _deltaTime = Time.deltaTime;
        _machine.Update();
        _currentStateName = _machine.GetCurrentStateName();
    }

    protected virtual void FixedUpdate()
    {
        _machine.FixedUpdate();
    }
}
