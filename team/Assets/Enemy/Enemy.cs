using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    //移動スピード
    [SerializeField] private float moveSpeed = 5.0f;

    //跳ね返る力
    [SerializeField] private float jumpPower = 10.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Walk();
    }

    //移動処理
    private void Walk()
    {
        //右向きなら左移動
        if (transform.localScale.x > 0)
        {
            rb.linearVelocity =
                new Vector2(-moveSpeed, rb.linearVelocity.y);
        }

        //左向きなら右移動
        else if (transform.localScale.x < 0)
        {
            rb.linearVelocity =
                new Vector2(moveSpeed, rb.linearVelocity.y);
        }
    }

    //踏まれた判定
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        //PlayerFootだけ反応
        if (other.CompareTag("PlayerFoot"))
        {
            //親(Player)のRigidbody取得
            Rigidbody2D playerRb =
                other.GetComponentInParent<Rigidbody2D>();

            //敵を倒す
            Destroy(gameObject);

            //プレイヤーを跳ね返す
            playerRb.linearVelocity =
                new Vector2(playerRb.linearVelocity.x, jumpPower);
        }
    }

    //横から接触した
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Player本体に当たった？
        if (collision.gameObject.CompareTag("Player"))
        {
            //シーン再読み込み
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name);
        }
    }
}