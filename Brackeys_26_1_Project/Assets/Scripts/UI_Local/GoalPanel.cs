using System.Collections;
using TMPro;
using UnityEngine;

public class GoalPanel : CanvasView
{
    [SerializeField] TextMeshProUGUI _text = null;
    [SerializeField] float _duration = 5f;

    public void Display(string _message)
    {
        InstantShow();
        _text.text = $"{_message}";
        StopAllCoroutines();
        StartCoroutine(Display_Routine());
    }

    private IEnumerator Display_Routine()
    {
        yield return new WaitForSeconds(_duration);
        Hide();
    }
}
