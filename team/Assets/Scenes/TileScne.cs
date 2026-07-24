using UnityEngine;
using UnityEngine.SceneManagement;

public class TileScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enterキー
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("アクション");
    }
}