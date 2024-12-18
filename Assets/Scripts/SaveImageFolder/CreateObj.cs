using UnityEngine;

public class CreateObj : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    void Start()
    {
        obj1.AddComponent<SpriteRenderer>();
        obj2.AddComponent<SpriteRenderer>();
        obj3.AddComponent<SpriteRenderer>();
    }
    public void OnClick()
    {
        AddCom1();
        AddCom2();
        AddCom3();
    }
    private void AddCom1()
    {
        SpriteRenderer sprd = obj1.GetComponent<SpriteRenderer>();
        sprd.sprite = SaveImage.spr1;
        obj1.AddComponent<Rigidbody2D>();
        obj1.AddComponent<PolygonCollider2D>();
    }
    private void AddCom2()
    {
        SpriteRenderer sprd = obj2.GetComponent<SpriteRenderer>();
        sprd.sprite = SaveImage.spr2;
        obj2.AddComponent<Rigidbody2D>();
        obj2.AddComponent<PolygonCollider2D>();
    }
    private void AddCom3()
    {
        SpriteRenderer sprd = obj3.GetComponent<SpriteRenderer>();
        sprd.sprite = SaveImage.spr3;
        obj3.AddComponent<Rigidbody2D>();
        obj3.AddComponent<PolygonCollider2D>();
    }
}
