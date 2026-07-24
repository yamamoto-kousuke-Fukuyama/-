using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpscareManager : MonoBehaviour
{
    [SerializeField] private float waitTime = 1.0f;

    void Start()
    {
        Invoke(nameof(GameOver), waitTime);
    }

    void GameOver()
    {
        SceneManager.LoadScene("Over");
    }
}