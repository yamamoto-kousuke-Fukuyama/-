using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float speed = 3f;
    public float interval = 1.5f;
    private void Start()
    {

        InvokeRepeating(nameof(Shoot), 1f, interval);
    }

    void Shoot()
    {
        for (int i = -3; i <= 3; i++)
        {


            GameObject arrow = Instantiate
                (
                arrowPrefab,
                transform.position + new Vector3(70+i*3f,-5,0),
                Quaternion.Euler(0, 0, -90)
                );

            Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.up * 50f;
        }
    }
}
