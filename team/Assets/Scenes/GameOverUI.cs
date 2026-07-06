using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    // 死亡回数を表示するText
    public TextMeshProUGUI countText;

    // ゲームオーバー表示時間
    public float waitTime = 3f;

    void Start()
    {
        // 死亡回数を取得（初期値0）
        int count = PlayerPrefs.GetInt("DeathCount", 0);

        // 数字を表示
        countText.text = $"-{count}";

        // 3秒後にゲームへ戻る
        Invoke(nameof(RestartStage), waitTime);
    }

    void RestartStage()
    {
        // 保存したステージ名を取得
        string stage = PlayerPrefs.GetString("CurrentStage", "TileScene");

        // ステージへ戻る
        SceneManager.LoadScene(stage);
    }

    // ゲーム終了時に死亡回数をリセット
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("DeathCount", 0);
        PlayerPrefs.Save();
    }
}