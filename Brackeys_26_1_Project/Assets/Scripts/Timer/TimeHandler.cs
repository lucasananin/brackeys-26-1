using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    [SerializeField] TimerSO _so = null;

    [Header("// RUNTIME")]
    [SerializeField] bool _isOn = false;

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
