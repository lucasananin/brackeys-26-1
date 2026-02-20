using TarodevController;
using UnityEngine;

public class PlayerStateController : StateController
{
    protected override void Start()
    {
        base.Start();
        ChangeToDefaultState();
    }

    private void OnEnable()
    {
        TimeHandler.OnTimerEnd += DisableCharacter;
        LevelHandler.OnAllLevelsFinished += DisableCharacter;
    }

    private void OnDisable()
    {
        TimeHandler.OnTimerEnd -= DisableCharacter;
        LevelHandler.OnAllLevelsFinished -= DisableCharacter;
    }

    private void DisableCharacter()
    {
        enabled = false;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        GetComponent<PlayerInteractAgent>().enabled = false;
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
