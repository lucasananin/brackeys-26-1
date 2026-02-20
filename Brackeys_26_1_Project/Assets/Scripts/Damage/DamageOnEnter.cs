using UnityEngine;

public class DamageOnEnter : DamageSource
{
    private void OnTriggerEnter2D(Collider2D _other)
    {
        if(_other.tag == "Sandfall")
        CauseDamage(_other);
    }
}
