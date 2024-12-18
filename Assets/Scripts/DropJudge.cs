using UnityEngine;
using UnityEngine.UI;

public class DropJudge : MonoBehaviour
{
    [SerializeField] GameObject GOcanvas;

    private void Start()
    {
        GOcanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Objects"))
        {
            // "Objects"タグを持つオブジェクトが触れた場合
            ToGameOver();
        }
    }
    private void ToGameOver()
    {
        GOcanvas.SetActive(true);
        // 時間を停止
        Time.timeScale = 0f;
    }
}

