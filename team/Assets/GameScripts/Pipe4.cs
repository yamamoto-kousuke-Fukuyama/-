using UnityEngine;

public class Pipe4 : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float detectDistance = 5f;
    [SerializeField] private float detectWidth = 1f;
    [SerializeField] private float moveSpeed = 5f;

    // SE
    [SerializeField] private AudioClip moveSE;
    private AudioSource audioSource;

    private bool isMoving = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (player == null) return;

        float xDistance = Mathf.Abs(player.position.x - transform.position.x);
        float yDistance = Mathf.Abs(player.position.y - transform.position.y);

        // プレイヤーが土管の下に来たら動く
        if (!isMoving &&
            player.position.y < transform.position.y &&
            xDistance <= detectWidth &&
            yDistance <= detectDistance)
        {
            isMoving = true;

            // 動き始める時にSE
            if (moveSE != null)
            {
                audioSource.PlayOneShot(moveSE);
            }
        }

        // 下へスライド
        if (isMoving)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
    }
}