using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //移動
    [SerializeField] private float moveSpeed = 10.0f;

    //ジャンプ
    [SerializeField] private float jumpForce = 15.0f;

    //プレイヤーの足元オブジェクト
    [SerializeField] private Transform GroundCheker;

    //地面チェックする円の半径
    [SerializeField] private float checkerRadius = 0.1f;

    //地面のレイヤー
    [SerializeField] private LayerMask groundLayer;

    //多段ジャンプ防止
    private bool isGround;

    //プレイヤー
    private Rigidbody2D rb;

    //アニメーション
    private Animator _anim;
    private SpriteRenderer sr;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        _anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Walk();
        Jump();

        //画面外に落ちたらリスタート
        if (transform.position.y < -9f)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name);
        }
    }


    //移動
    private void Walk()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        rb.linearVelocityX = direction * moveSpeed;

        _anim.SetBool("isWalk", direction != 0);


        if (direction > 0)
        {
            sr.flipX = false;
        }
        else if (direction < 0)
        {
            sr.flipX = true;
        }
    }


    //ジャンプ
    private void Jump()
    {
        if (Physics2D.OverlapCircle(
            GroundCheker.position,
            checkerRadius,
            groundLayer))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }


        if ((Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.Space))
            && isGround == true)
        {
            rb.AddForce(
                Vector2.up * jumpForce,
                ForceMode2D.Impulse);

            _anim.SetBool("isJump", true);
        }


        if (isGround)
        {
            _anim.SetBool("isJump", false);
        }
        else
        {
            _anim.SetBool("isJump", true);
        }
    }


    //ブロック破壊処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Blockタグのブロックか確認
        if (collision.gameObject.CompareTag("Block"))
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                // プレイヤーが下からブロックに当たった場合
                if(point.normal.y < -0.5f)
                {
                    BreakBlock block = collision.gameObject.GetComponent<BreakBlock>();

                    if (block != null)
                    {
                        block.DestroyBlock();
                    }
                }
            }
        }
    }
}