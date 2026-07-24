using UnityEngine;

public class Pipe3 : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float detectDistance = 5f; // 横方向の検知距離
    [SerializeField] private float detectHeight = 1f;   // 高さの許容範囲
    [SerializeField] private float moveSpeed = 5f;

    private bool isMoving = false;

    void Update()
    {
        if (player == null) return;

        // 横方向の距離
        float xDistance = Mathf.Abs(player.position.x - transform.position.x);

        // 高さの差
        float yDistance = Mathf.Abs(player.position.y - transform.position.y);

        // 横方向5m以内 かつ 高さ1m以内
        if (!isMoving &&
            xDistance <= detectDistance &&
            yDistance <= detectHeight)
        {
            isMoving = true;
        }

        // 左へスライド
        if (isMoving)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}