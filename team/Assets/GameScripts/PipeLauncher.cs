using UnityEngine;

public class PipeLauncher : MonoBehaviour
{
    [SerializeField] private float launchPower = 15f;

    //SE
    [SerializeField] private AudioClip launchSE;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // è„Ç…îÚÇ‘SE
            if (launchSE != null)
            {
                audioSource.PlayOneShot(launchSE);
            }

            rb.linearVelocity = Vector2.zero;
            rb.AddForce(Vector2.up * launchPower, ForceMode2D.Impulse);
        }
    }
}