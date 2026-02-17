using TarodevController;

public class PlayerHurtState : IState
{
    private PlayerStateController _controller = null;
    private PlayerController _mover = null;
    private HealthBehaviour _health = null;
    private float _timer = 0;

    public void Awake(StateController _controller)
    {
        this._controller = _controller as PlayerStateController;
        _mover = _controller.GetComponent<PlayerController>();
        _health = _controller.GetComponent<HealthBehaviour>();
    }

    public string GetStateName()
    {
        return "Hurt";
    }

    public void OnEnter()
    {
        float _xDirection = _health.LastDamageSource.transform.position.x > _controller.transform.position.x ? -1f : 1f;
        _mover.Knockback(_xDirection);
    }

    public void OnExit()
    {
        // enable iFrames.
    }

    public void OnUpdate()
    {
        _timer += _controller.DeltaTime;

        if (_timer > .1f && _mover.IsGrounded())
        {
            _controller.ChangeToDefaultState();
        }
    }

    public void FixedUpdate()
    {
        _mover.CheckCollisions();
        _mover.HandleGravity();
        _mover.ApplyMovement();
    }
}
