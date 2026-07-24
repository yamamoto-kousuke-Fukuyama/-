using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakBlock2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Jumpscare");
        }
    }
}

