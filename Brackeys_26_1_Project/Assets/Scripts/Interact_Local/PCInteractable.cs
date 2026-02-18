using UnityEngine;

public class PCInteractable : InteractableBehaviour
{
    public override void Interact(InteractAgent _agent)
    {
        base.Interact(_agent);
        //Debug.Log($"PC Interacted with");
    }

    public override string GetText()
    {
        return "Mission Info";
    }
}
