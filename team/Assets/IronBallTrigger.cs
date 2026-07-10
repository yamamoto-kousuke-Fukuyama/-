using UnityEngine;

public class IronBallTrigger:MonoBehaviour
{

    public Rigidbody2D ironBall;
    private bool dropped = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!dropped && other.CompareTag("Player"))
        {
            dropped = true;

            ironBall.gravityScale = 70;
        }
    }

}
