using UnityEngine;

public class IronBall : MonoBehaviour 
{
 
    public float fallSpeed = 20f;

    private void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = Vector2.down*fallSpeed;
    }

}
