using TarodevController;

public class PlayerDefaultState : IState
{
    private PlayerController _mover = null;
    private SideFlipper _flipper = null;

    public void Awake(StateController _controller)
    {
        _mover = _controller.GetComponent<PlayerController>();
        _flipper = _controller.GetComponent<SideFlipper>();
    }

    public string GetStateName()
    {
        return $"Default";
    }

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
        _mover.GatherInput();

        if (_mover.FrameInput.x > 0)
            _flipper.Flip(true);
        else if (_mover.FrameInput.x < 0)
            _flipper.Flip(false);
    }

    public void FixedUpdate()
    {
        _mover.CheckCollisions();
        _mover.HandleJump();
        _mover.HandleDirection();
        _mover.HandleGravity();
        _mover.ApplyMovement();
    }
}
