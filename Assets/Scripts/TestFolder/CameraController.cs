using UnityEngine;

public class CameraController : MonoBehaviour {

    public static bool isCollision;//衝突検出変数

    // 衝突中を伝えるメソッド
    private void OnTriggerStay2D(Collider2D collision)
    {
        isCollision = true;
        //Debug.Log(isCollision);
    }

    // 衝突終了を伝えるメソッド
    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollision = false;
    }
}