using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] List<LevelData> _levelList = null;

    internal LevelData GetData()
    {
        var _index = 0;
        return _levelList[_index];
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