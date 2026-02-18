using UnityEngine;

[CreateAssetMenu(fileName = "TimerSO", menuName = "Scriptable Objects/TimerSO")]
public class TimerSO : ScriptableObject
{
    [SerializeField] float _maxTimeInMinutes = 30f;

    [Header("// RUNTIME")]
    [SerializeField] float _timer = 0f;

    public float Timer { get => _timer; }

    public void DecreaseTimer(float _t)
    {
        _timer -= _t;

        if (_timer <= 0)
            _timer = 0;
    }

    public void ResetTime()
    {
        _timer = _maxTimeInMinutes * 60f;
    }

    public string GetString()
    {
        return $"{Mathf.FloorToInt(_timer / 60f):00}:{Mathf.FloorToInt(_timer % 60f):00}";
    }
}
