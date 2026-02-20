using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PCView : CanvasView
{
    [Space]
    [SerializeField] GameDataSO _so = null;
    [SerializeField] Button _startButton = null;
    [SerializeField] Button _closeButton = null;
    [Space]
    [SerializeField] TextMeshProUGUI _title = null;
    [SerializeField] TextMeshProUGUI _description = null;
    [SerializeField] Image _icon = null;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OpenPortal);
        _closeButton.onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OpenPortal);
        _closeButton.onClick.RemoveListener(Hide);
    }

    public override void Show()
    {
        base.Show();
        UpdateVisuals();
    }

    public override void InstantShow()
    {
        base.InstantShow();
        UpdateVisuals();
    }

    public void UpdateVisuals()
    {
        var _data = FindAnyObjectByType<LevelHandler>().GetData();
        _title.text = $"{_data.DisplayName}";
        _description.text = $"{_data.Description}";
        _icon.sprite = _data.Icon;
        _so.SceneToPortal = _data.SceneName;
    }

    public void OpenPortal()
    {
        var _portal = FindAnyObjectByType<PortalInteractable>();
        _portal.Init();
        var _shelve = FindAnyObjectByType<Shelve>();
        _shelve.SpawnPackage();
        var _timerHandler = FindAnyObjectByType<TimeHandler>();
        _timerHandler.Init();
        var _goalPanel = FindAnyObjectByType<GoalPanel>();
        _goalPanel.Display($"Portal Opened!");

        Hide();
    }
}
