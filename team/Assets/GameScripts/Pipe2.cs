using UnityEngine;

public class Pipe2 : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float detectDistance = 5f;
    [SerializeField] private float moveSpeed = 5f;

    //SE
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

        // プレイヤーとの距離
        float distance = Vector2.Distance(transform.position, player.position);

        // 一定距離以内なら動き始める
        if (!isMoving && distance <= detectDistance)
        {
            isMoving = true;

            // 動き始めのSE
            if (moveSE != null)
            {
                audioSource.PlayOneShot(moveSE);
            }
        }

        // 左へスライド
        if (isMoving)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}