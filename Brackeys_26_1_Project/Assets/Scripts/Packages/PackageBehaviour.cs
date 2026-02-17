using System.Collections;
using UnityEngine;

public class PackageBehaviour : MonoBehaviour
{
    [SerializeField] BoxCollider2D _collider = null;

    private IEnumerator Start()
    {
        _collider.isTrigger = true;
        yield return new WaitForSeconds(.1f);
        _collider.isTrigger = false;
    }
}
