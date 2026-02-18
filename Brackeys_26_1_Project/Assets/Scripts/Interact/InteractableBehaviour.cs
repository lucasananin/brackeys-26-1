using UnityEngine;
using UnityEngine.Events;

public abstract class InteractableBehaviour : MonoBehaviour
{
    [SerializeField] UnityEvent _onInteracted = null;

    public virtual void Interact(InteractAgent _agent)
    {
        _onInteracted.Invoke();
    }

    public abstract string GetText();
}
