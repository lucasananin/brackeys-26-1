using TarodevController;

public class PlayerHurtState : IState
{
    private PlayerStateController _controller = null;
    private PlayerController _mover = null;
    private float _timer = 0;

    public void Awake(StateController _controller)
    {
        this._controller = _controller as PlayerStateController;
        _mover = _controller.GetComponent<PlayerController>();
    }

    public string GetStateName()
    {
        return "Hurt";
    }

    public void OnEnter()
    {
        // set frame velocity to the opposite of damage source.
        _mover.Knockback(-1f);
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
