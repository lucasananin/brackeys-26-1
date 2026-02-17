using TarodevController;

public class PlayerDefaultState : IState
{
    private PlayerController _mover = null;

    public void Awake(StateController _controller)
    {
        _mover = _controller.GetComponent<PlayerController>();
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
