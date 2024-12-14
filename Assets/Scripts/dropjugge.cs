using UnityEngine;

public class TriggerCanvasDisplay : MonoBehaviour
{
    public GameObject canvasToDisplay;

    private void Start()
    {
        // 最初はキャンバスを非表示にしておく
        if (canvasToDisplay != null)
        {
            canvasToDisplay.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // "Objects"タグを持つオブジェクトが触れた場合
        if (collision.CompareTag("Objects"))
        {
            // キャンバスを表示
            if (canvasToDisplay != null)
            {
                canvasToDisplay.SetActive(true);
            }

            // 時間を停止
            Time.timeScale = 0f;
        }
    }
}

