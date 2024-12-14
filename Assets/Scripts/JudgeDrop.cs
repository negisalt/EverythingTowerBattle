using UnityEngine;
using UnityEngine.UI;

public class JudgeDrop : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject playPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        playPanel.SetActive(true);
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
        gameOverPanel.SetActive(true);
        playPanel.SetActive(false);

        // 時間を停止
        Time.timeScale = 0f;
    }
}

