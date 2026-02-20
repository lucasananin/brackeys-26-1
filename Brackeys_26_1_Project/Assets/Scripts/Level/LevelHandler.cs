using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] List<LevelData> _levelList = null;
    [SerializeField] GameDataSO _so = null;

    public static event UnityAction OnAllLevelsFinished = null;

    private void Start()
    {
        if (_so.LevelIndex >= _levelList.Count)
        {
            // show victory panel.
            _so.LevelIndex = 0;
            OnAllLevelsFinished?.Invoke();
        }
    }

    internal LevelData GetData()
    {
        var _index = _so.LevelIndex;

        if (_index < _levelList.Count)
            return _levelList[_index];
        else
            return _levelList[^1];
    }
}

[System.Serializable]
public class LevelData
{
    [SerializeField] string _displayName = null;
    [SerializeField] string _description = null;
    [SerializeField] string _sceneName = null;
    [SerializeField] Sprite _icon = null;

    public string DisplayName { get => _displayName; }
    public string Description { get => _description; }
    public Sprite Icon { get => _icon; }
    public string SceneName { get => _sceneName; }
}