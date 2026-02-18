using TMPro;
using UnityEngine;

public class PlayerInteractPanel : MonoBehaviour
{
    [SerializeField] CanvasView _view = null;
    [SerializeField] TextMeshProUGUI _text = null;

    private void OnEnable()
    {
        PlayerInteractAgent.OnInteractableChange += UpdateVisuals;
        PlayerInteractAgent.OnInteracted += UpdateVisuals;
    }

    private void OnDisable()
    {
        PlayerInteractAgent.OnInteractableChange -= UpdateVisuals;
        PlayerInteractAgent.OnInteracted -= UpdateVisuals;
    }

    private void UpdateVisuals(InteractableBehaviour _interactableBehaviour)
    {
        if (_interactableBehaviour is null)
        {
            _view.Hide();
        }
        else
        {
            transform.parent.position = _interactableBehaviour.transform.position;
            _view.Show();
            _text.text = $"{_interactableBehaviour.GetText()}";
        }
    }
}
