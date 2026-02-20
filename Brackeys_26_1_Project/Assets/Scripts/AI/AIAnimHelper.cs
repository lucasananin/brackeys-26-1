using UnityEngine;

public class AIAnimHelper : MonoBehaviour
{
    //[SerializeField] DamageSource _damageSource = null;
    [SerializeField] Collider2D _damageCollider = null;

    public void EnableDamageSource()
    {
        //_damageSource.gameObject.SetActive(true);
        _damageCollider.enabled = true;
    }

    public void DisableDamageSource()
    {
        //_damageSource.gameObject.SetActive(false);
        _damageCollider.enabled = false;
    }
}
