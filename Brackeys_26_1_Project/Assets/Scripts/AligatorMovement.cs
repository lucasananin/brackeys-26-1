using UnityEngine;

public class AligatorMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;

    void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
        
        if (direction.x > 0)
            transform.localScale = new Vector2(-1, 1);
        else if (direction.x < 0)
            transform.localScale = new Vector2(1, 1);
    }
}
