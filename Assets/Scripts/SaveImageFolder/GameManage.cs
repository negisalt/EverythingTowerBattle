using UnityEngine;

public class GameManage : MonoBehaviour
{
    private Vector2 mouPos;
    private Vector2 pos;
    private int fallObj;
    private bool created;
    private int randomNum;
    private GameObject obj;
    private Rigidbody2D rb;
    public PhysicsMaterial2D fri;
    static public float height;
    void Start()
    {
        randomNum = 0;
        fallObj = 0;
        height = 0.0f;
        created = true;
    }
    public void Update()
    {
        mouPos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(new Vector2(mouPos.x, 720));
        if (fallObj == 0)//生成
        {
            CreateObj();
            fallObj = 1;
        }
        else if (fallObj == 1)//横移動＆落とす
        {
            rb.MovePosition(pos);
            Roaring();

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

        High();
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
            Original00();
            rb = obj.GetComponent<Rigidbody2D>();
            created = false;
            Debug.Log("CreateObj -> Done");
        }
    }
    private void Roaring()
    {
        if (Input.GetKey(KeyCode.A))//KinematicにしてるからAddTorqueだと回らない
        {
            obj.transform.Rotate(0, 0, 2);
            //rb.AddTorque(200, ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            obj.transform.Rotate(0, 0, -2);
            //rb.AddTorque(-200, ForceMode2D.Force);
        }
    }
    private void Original00()
    {
        obj = new GameObject();
        obj.AddComponent<SpriteRenderer>();
        SpriteRenderer sprd = obj.GetComponent<SpriteRenderer>();

        if (randomNum == 1)
        {
            sprd.sprite = SaveImage.spr1;
        }
        else if (randomNum == 2)
        {
            sprd.sprite = SaveImage.spr2;
        }
        else if (randomNum == 3)
        {
            sprd.sprite = SaveImage.spr3;
        }

        obj.AddComponent<PolygonCollider2D>();
        obj.GetComponent<PolygonCollider2D>().sharedMaterial = fri;
        rb = obj.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        Vector2 po = Camera.main.ScreenToWorldPoint(new Vector2(500, 1000));
        obj.transform.position = po;
    }
    public void High()
    {
        height = obj.transform.position.y;
        Debug.Log("Height = " + height);
    }
}
