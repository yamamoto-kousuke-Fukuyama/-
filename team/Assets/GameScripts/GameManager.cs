using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        // 前回ゲームが終了していたら死亡回数をリセット
        if (PlayerPrefs.GetInt("GameClosed", 1) == 1)
        {
            PlayerPrefs.SetInt("DeathCount", 0);
        }

        // ゲーム起動中
        PlayerPrefs.SetInt("GameClosed", 0);
        PlayerPrefs.Save();
    }

    // ゲーム終了時
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("GameClosed", 1);
        PlayerPrefs.Save();
    }
}