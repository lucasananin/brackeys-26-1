using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text = null;
    [SerializeField] TimerSO _so = null;

    private void LateUpdate()
    {
        _text.text = _so.GetString();
        //if (_so.Timer > 0 && _so.Timer < _so.MaxTimeInMinutes)
        //    _text.text = _so.GetString();
        //else
        //    _text.text = $"--:--";
    }
}
