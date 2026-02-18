using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalInteractable : InteractableBehaviour
{
    [SerializeField] SceneLoader _sceneLoader = null;
    [SerializeField] GameDataSO _so = null;
    [SerializeField] Collider2D _collider = null;
    [SerializeField] GameObject _renderer = null;

    private void Start()
    {
        _renderer.SetActive(false);
    }

    public override void Interact(InteractAgent _agent)
    {
        base.Interact(_agent);

        _collider.enabled = false;
        _sceneLoader.SetValues(_so.SceneToPortal, SceneManager.GetActiveScene().name);
        _sceneLoader.Load();
    }

    public override string GetText()
    {
        return "Use Portal";
    }

    internal void Init()
    {
        _collider.enabled = true;
        _renderer.SetActive(true);
    }
}
