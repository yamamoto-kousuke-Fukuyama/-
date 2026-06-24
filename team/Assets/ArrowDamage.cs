using UnityEngine;

public class ArrowDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}