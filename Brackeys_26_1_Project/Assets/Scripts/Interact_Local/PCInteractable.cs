using UnityEngine;

public class PCInteractable : InteractableBehaviour
{
    public override void Interact(InteractAgent _agent)
    {
        base.Interact(_agent);
        var _view = FindAnyObjectByType<PCView>();
        _view.Show();
    }

    public override string GetText()
    {
        return "Mission Info";
    }
}
