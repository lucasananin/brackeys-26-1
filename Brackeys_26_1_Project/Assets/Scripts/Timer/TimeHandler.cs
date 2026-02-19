using UnityEngine;
using UnityEngine.Events;

public class TimeHandler : MonoBehaviour
{
    [SerializeField] TimerSO _so = null;

    [Header("// RUNTIME")]
    [SerializeField] bool _isOn = false;

    public static event UnityAction OnTimerEnd = null;

    //private void Start()
    //{
    //    Init();
    //}

    private void Update()
    {
        if (_isOn)
        {
            _so.DecreaseTimer(Time.deltaTime);

            if (_so.Timer <= 0)
            {
                End();
                OnTimerEnd?.Invoke();
            }
        }
    }

    public void Init()
    {
        _isOn = true;
        _so.ResetTime();
    }

    public void End()
    {
        _isOn = false;
        _so.ResetTime();
    }
}
