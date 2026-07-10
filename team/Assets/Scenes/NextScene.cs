using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private float waitTime = 2.0f;

    void Start()
    {
        Invoke(nameof(LoadStage2), waitTime);
    }

    void LoadStage2()
    {
        SceneManager.LoadScene("ƒAƒNƒVƒ‡ƒ“2");
    }
}