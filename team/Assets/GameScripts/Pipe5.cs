using UnityEngine;

public class Pipe5 : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float detectDistance = 5f;
    [SerializeField] private float detectWidth = 1f;

    [SerializeField] private float downSpeed = 5f;
    [SerializeField] private float rightSpeed = 5f;

    // SE
    [SerializeField] private AudioClip downSE;
    [SerializeField] private AudioClip rightSE;

    private AudioSource audioSource;

    private bool moveDown = false;
    private bool moveRight = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (player == null) return;

        float xDistance = Mathf.Abs(player.position.x - transform.position.x);
        float yDistance = Mathf.Abs(player.position.y - transform.position.y);

        // プレイヤーが土管の真下に来たら動き始める
        if (!moveDown && !moveRight &&
            player.position.y < transform.position.y &&
            xDistance <= detectWidth &&
            yDistance <= detectDistance)
        {
            moveDown = true;

            // 下移動SE
            if (downSE != null)
            {
                audioSource.PlayOneShot(downSE);
            }
        }

        // 下へ移動
        if (moveDown)
        {
            transform.Translate(Vector2.down * downSpeed * Time.deltaTime);

            // プレイヤーの高さまで来たら右へ移動
            if (transform.position.y <= player.position.y)
            {
                moveDown = false;
                moveRight = true;

                // 右移動SE
                if (rightSE != null)
                {
                    audioSource.PlayOneShot(rightSE);
                }
            }
        }

        // 右へ移動
        if (moveRight)
        {
            transform.Translate(Vector2.right * rightSpeed * Time.deltaTime);
        }
    }
}