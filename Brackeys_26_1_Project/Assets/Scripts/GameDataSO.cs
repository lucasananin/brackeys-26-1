using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDataSO", menuName = "Scriptable Objects/GameDataSO")]
public class GameDataSO : ScriptableObject
{
    [SerializeField] string _warehouseSceneName = null;
    [SerializeField] string _mainMenuSceneName = null;

    [Header("// RUNTIME")]
    [SerializeField] string _SceneToPortal = null;
    [SerializeField] int _packageAmount = 0;
    [SerializeField] int _levelIndex = 0;

    public string SceneToPortal { get => _SceneToPortal; set => _SceneToPortal = value; }
    public int PackageAmount { get => _packageAmount; set => _packageAmount = value; }
    public int LevelIndex { get => _levelIndex; set => _levelIndex = value; }

    private void OnEnable()
    {
        _levelIndex = 0;
    }

    internal void SetWarehouseScene()
    {
        _SceneToPortal = _warehouseSceneName;
    }

    internal void SetMainMenuScene()
    {
        _SceneToPortal = _mainMenuSceneName;
    }
}
