using UnityEngine;

public class Mailbox : InteractableBehaviour
{
    [SerializeField] PortalInteractable _portal = null;
    [SerializeField] GameDataSO _so = null;

    public override void Interact(InteractAgent _agent)
    {
        base.Interact(_agent);

        var _packageHolder = _agent.GetComponent<PackageHolder>();
        if (!_packageHolder.HasPackage()) return;
        // decrease amount.

        _so.SetWarehouseScene();
        _portal.Init();
    }

    public override string GetText()
    {
        return "Deliver Package";
    }
}
