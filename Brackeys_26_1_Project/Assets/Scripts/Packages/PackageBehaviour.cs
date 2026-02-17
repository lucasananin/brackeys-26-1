using System.Collections;
using UnityEngine;

public class PackageBehaviour : MonoBehaviour
{
    [SerializeField] BoxCollider2D _collider = null;
    [SerializeField] TagCollectionSO _playerTags = null;

    private bool _isGrabbed = false;

    private IEnumerator Start()
    {
        _collider.isTrigger = true;
        yield return new WaitForSeconds(.1f);
        _collider.isTrigger = false;
    }

    private void OnCollisionEnter2D(Collision2D _other)
    {
        if (_isGrabbed) return;

        if (_playerTags.HasTag(_other.gameObject))
        {
            _isGrabbed = true;
            _other.gameObject.GetComponent<PackageHolder>().IncreaseAmount();
            Destroy(gameObject);
        }
    }
}
