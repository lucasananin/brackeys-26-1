using UnityEngine;

public class GameOverPanel : CanvasView
{
    private void OnEnable()
    {
        TimeHandler.OnTimerEnd += Show;
    }

    private void OnDisable()
    {
        TimeHandler.OnTimerEnd -= Show;
    }
}
