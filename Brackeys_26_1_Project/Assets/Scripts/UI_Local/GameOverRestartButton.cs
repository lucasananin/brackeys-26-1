using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverRestartButton : SceneLoaderButton
{
    [SerializeField] GameDataSO _so = null;

    public override void Load()
    {
        _so.SetWarehouseScene();
        SetValues(_so.SceneToPortal, SceneManager.GetActiveScene().name);
        base.Load();
    }
}
