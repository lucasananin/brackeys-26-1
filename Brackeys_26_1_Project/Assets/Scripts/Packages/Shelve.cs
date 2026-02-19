using UnityEngine;

public class Shelve : MonoBehaviour
{
    [SerializeField] Rigidbody2D _prefab = null;
    [SerializeField] Transform _point = null;

    public void SpawnPackage()
    {
        var _instance = Instantiate(_prefab, _point.position, Quaternion.identity);
    }
}
