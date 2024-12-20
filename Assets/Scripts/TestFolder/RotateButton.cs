using UnityEngine;
using UnityEngine.EventSystems;

public class RotateButton : MonoBehaviour, IPointerDownHandler{

    public static bool onButtonDown;//ボタンがクリックされてるかを判定！

    // ボタンが押されたと検出
    public void OnPointerDown(PointerEventData eventData)
    {
        onButtonDown = true;
    }
}