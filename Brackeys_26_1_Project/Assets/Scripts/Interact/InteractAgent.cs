using System.Collections.Generic;
using UnityEngine;

public abstract class InteractAgent : MonoBehaviour
{
    [SerializeField] protected ContactFilter2D _filter = default;
    [SerializeField] protected float _radius = 1f;

    [Header("// RUNTIME")]
    [SerializeField] protected InteractableBehaviour _currentInteractable = null;

    private Collider2D[] _results = new Collider2D[9];
    private List<Collider2D> _resultsList = new();

    protected virtual InteractableBehaviour SearchForInteractables()
    {
        int _hits = Physics2D.OverlapCircle(transform.position, _radius, _filter, _results);

        UpdateResultsList(_hits);

        for (int i = 0; i < _hits; i++)
        {
            var _colliderHit = _resultsList[i];

            if (_colliderHit.TryGetComponent(out InteractableBehaviour _interactableBehaviour))
            {
                return _interactableBehaviour;
            }
        }

        return null;
    }

    private void UpdateResultsList(int _hits)
    {
        _resultsList.Clear();

        for (int i = 0; i < _hits; i++)
        {
            _resultsList.Add(_results[i]);
        }

        _resultsList = GeneralMethods.OrderListByDistance(_resultsList, transform.position);
    }
}
