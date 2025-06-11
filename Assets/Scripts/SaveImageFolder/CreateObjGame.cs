using UnityEngine;

public class CreateObjGame : MonoBehaviour
{
    private int count;
    private Vector2 mouPos;
    private int fallObj;
    private bool created;
    private int randomNum;
    private Vector2 pos;
    private GameObject obj;
    private GameObject obj1;
    private GameObject obj2;
    private GameObject obj3;
    private Rigidbody2D rb;
    void Start()
    {
        Original01();
        Original02();
        Original03();
        count = 0;
        randomNum = 0;
        fallObj = 0;//leaveMouse
        created = true;
    }
    public void Update()
    {
        mouPos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(new Vector2(mouPos.x, 300));
        if (fallObj == 0)//生成
        {
            CreateObj();
            fallObj = 1;
        }
        else if (fallObj == 1)//横移動＆落とす
        {
            rb.MovePosition(pos);
            if (Input.GetMouseButtonDown(0))
            {
                obj.transform.position = pos;
                rb.bodyType = RigidbodyType2D.Dynamic;
                fallObj = 2;
                created = true;
            }
        }
        else if (fallObj == 2)//待機
        {
            Invoke("Timer", 2.0f);
        }
        Debug.Log("fallObj -> " + fallObj);
        Debug.Log("created -> " + created);
    }
    private void Timer()
    {
        fallObj = 0;
    }
    private void CreateObj()
    {
        randomNum = Random.Range(1, 4);
        if (created)
        {
            if (randomNum == 1)
            {
                obj = Instantiate(obj1);
            }
            else if (randomNum == 2)
            {
                obj = Instantiate(obj2);
            }
            else if (randomNum == 3)
            {
                obj = Instantiate(obj3);
            }
            rb = obj.GetComponent<Rigidbody2D>();
            created = false;
            Debug.Log("CreateObj -> Done");
        }
    }
    private void Original01()
    {
        obj1 = new GameObject();
        obj1.AddComponent<SpriteRenderer>();
        SpriteRenderer sprd = obj1.GetComponent<SpriteRenderer>();
        sprd.sprite = SaveImage.spr1;
        obj1.AddComponent<PolygonCollider2D>();
        Rigidbody2D rb1 = obj1.AddComponent<Rigidbody2D>();
        rb1.bodyType = RigidbodyType2D.Kinematic;

        Vector2 o1 = Camera.main.ScreenToWorldPoint(new Vector2(0, 500));
        obj1.transform.position = o1;
    }
    private void Original02()
    {
        obj2 = new GameObject();
        obj2.AddComponent<SpriteRenderer>();
        SpriteRenderer sprd = obj2.GetComponent<SpriteRenderer>();
        sprd.sprite = SaveImage.spr2;
        obj2.AddComponent<PolygonCollider2D>();
        Rigidbody2D rb2 = obj2.AddComponent<Rigidbody2D>();
        rb2.bodyType = RigidbodyType2D.Kinematic;

        Vector2 o2 = Camera.main.ScreenToWorldPoint(new Vector2(50, 500));
        obj2.transform.position = o2;
    }
    private void Original03()
    {
        obj3 = new GameObject();
        obj3.AddComponent<SpriteRenderer>();
        SpriteRenderer sprd = obj3.GetComponent<SpriteRenderer>();
        sprd.sprite = SaveImage.spr3;
        obj3.AddComponent<PolygonCollider2D>();
        Rigidbody2D rb3 = obj3.AddComponent<Rigidbody2D>();
        rb3.bodyType = RigidbodyType2D.Kinematic;

        Vector2 o3 = Camera.main.ScreenToWorldPoint(new Vector2(100, 500));
        obj2.transform.position = o3;
    }
}
