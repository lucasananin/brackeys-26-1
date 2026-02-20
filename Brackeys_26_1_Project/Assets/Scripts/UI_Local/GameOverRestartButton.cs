using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverRestartButton : SceneLoaderButton
{
    [SerializeField] GameDataSO _so = null;
    [SerializeField] bool _isQuitButton = false;

    public override void Load()
    {
        if (_isQuitButton)
        {
            _so.SetMainMenuScene();
            SetValues(_so.SceneToPortal, SceneManager.GetActiveScene().name);
        }
        else
        {
            _so.SetWarehouseScene();
            SetValues(_so.SceneToPortal, SceneManager.GetActiveScene().name);
        }

        base.Load();
    }
}
