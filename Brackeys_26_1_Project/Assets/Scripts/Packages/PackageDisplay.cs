using UnityEngine;

public class PackageDisplay : MonoBehaviour
{
    [SerializeField] GameDataSO _so = null;
    [SerializeField] CanvasGroup _canvasGroup = null;

    private void LateUpdate()
    {
        _canvasGroup.alpha = _so.PackageAmount > 0 ? 1 : 0.1f;
    }
}
