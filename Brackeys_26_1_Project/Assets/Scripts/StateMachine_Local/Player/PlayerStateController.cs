using UnityEngine;

public class PlayerStateController : StateController
{
    protected override void Start()
    {
        base.Start();
        ChangeToDefaultState();
    }
    
    
    public void ChangeToHurtState()
    {
        _machine.ChangeState(new PlayerHurtState(), this);
    }

    public void ChangeToDefaultState()
    {
        _machine.ChangeState(new PlayerDefaultState(), this);
    }
}
