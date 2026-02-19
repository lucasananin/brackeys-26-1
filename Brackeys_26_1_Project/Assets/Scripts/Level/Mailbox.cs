using UnityEngine;

public class Mailbox : InteractableBehaviour
{
    [SerializeField] PortalInteractable _portal = null;
    [SerializeField] GameDataSO _so = null;

    private void Start()
    {
        var _goalPanel = FindAnyObjectByType<GoalPanel>();
        _goalPanel.Display($"Find the Mailbox!");
    }

    public override void Interact(InteractAgent _agent)
    {
        base.Interact(_agent);

        var _packageHolder = _agent.GetComponent<PackageHolder>();
        if (!_packageHolder.HasPackage()) return;
        _packageHolder.DecreaseAmount();

        var _goalPanel = FindAnyObjectByType<GoalPanel>();
        _goalPanel.Display($"Get back to the Portal!");

        _so.SetWarehouseScene();
        _portal.Init();
    }

    public override string GetText()
    {
        return "Deliver Package";
    }
}
