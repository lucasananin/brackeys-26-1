using UnityEngine;

[CreateAssetMenu(fileName = "GameDataSO", menuName = "Scriptable Objects/GameDataSO")]
public class GameDataSO : ScriptableObject
{
    [SerializeField] string _SceneToPortal = null;

    public string SceneToPortal { get => _SceneToPortal; set => _SceneToPortal = value; }
}
