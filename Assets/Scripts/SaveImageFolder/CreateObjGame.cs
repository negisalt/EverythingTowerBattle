using UnityEngine;

public class CreateObjGame : MonoBehaviour
{
    private float count;
    void Start()
    {
        count = 0.0f;
    }
    public void OnClick()
    {
        count++;
        GameObject obj1 = new GameObject("obj" + count);
        obj1.AddComponent<SpriteRenderer>();
        SpriteRenderer sprd = obj1.GetComponent<SpriteRenderer>();
        sprd.sprite = SaveImage.spr1;
        obj1.AddComponent<Rigidbody2D>();
        obj1.AddComponent<PolygonCollider2D>();
    }
}
