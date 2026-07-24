using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    //ブロック破壊SE
    [SerializeField] private AudioClip breakSE;

    //ブロックが壊れる処理
    public void DestroyBlock()
    {
        //SEを再生
        AudioSource.PlayClipAtPoint(
            breakSE,
            transform.position);

        //ブロックを削除
        Destroy(gameObject);
    }
}