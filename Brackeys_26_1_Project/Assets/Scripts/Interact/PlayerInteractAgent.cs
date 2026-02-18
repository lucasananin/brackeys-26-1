using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractAgent : InteractAgent
{
    public static event System.Action<InteractableBehaviour> OnInteractableChange = null;
    public static event System.Action<InteractableBehaviour> OnInteracted = null;

    private void OnEnable()
    {
        InputHandler.OnInteractDown += TryInteract;
    }

    private void OnDisable()
    {
        InputHandler.OnInteractDown -= TryInteract;
    }

    private void Update()
    {
        InteractableBehaviour _lastInteractable = _currentInteractable;
        _currentInteractable = SearchForInteractables();

        if (_currentInteractable != _lastInteractable)
        {
            OnInteractableChange?.Invoke(_currentInteractable);
        }
    }

    private void TryInteract()
    {
        if (_currentInteractable == null) return;

        _currentInteractable.Interact(this);
        OnInteracted?.Invoke(_currentInteractable);
    }
}
