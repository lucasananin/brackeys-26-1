using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text = null;
    [SerializeField] TimerSO _so = null;

    private void LateUpdate()
    {
        _text.text = _so.GetString();
    }
}
