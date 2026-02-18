using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDataSO", menuName = "Scriptable Objects/GameDataSO")]
public class GameDataSO : ScriptableObject
{
    [SerializeField] string _warehouseSceneName = null;

    [Header("// RUNTIME")]
    [SerializeField] string _SceneToPortal = null;
    [SerializeField] int _packageAmount = 0;

    public string SceneToPortal { get => _SceneToPortal; set => _SceneToPortal = value; }

    internal void SetWarehouseScene()
    {
        _SceneToPortal = _warehouseSceneName;
    }
}
