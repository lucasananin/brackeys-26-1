using UnityEngine;

public class TimeStopper : MonoBehaviour
{
    [SerializeField] PortalInteractable _portal = null;

    private void OnEnable()
    {
        _portal.OnInteracted += StopTime;
    }

    private void OnDisable()
    {
        _portal.OnInteracted -= StopTime;
    }

    private void StopTime()
    {
        var _timeHandler = FindAnyObjectByType<TimeHandler>();
        _timeHandler.End();
    }
}
