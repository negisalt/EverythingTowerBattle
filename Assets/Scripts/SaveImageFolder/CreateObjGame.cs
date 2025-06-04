using UnityEngine;

public class CreateObjGame : MonoBehaviour
{
    private int count;
    private Vector2 mouPos;
    private int fallObj;
    private int randomNum;
    private Vector2 pos;
    private GameObject obj;
    private GameObject obj1;
    private GameObject obj2;
    void Start()
    {
        Original01();
        Original02();
        count = 0;
        randomNum = 0;
        fallObj = 0;//leaveMouse
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
            if (Input.GetMouseButtonDown(0))
            {
                obj.transform.position = pos;
                fallObj = 2;
            }
        }
        else if (fallObj == 2)//待機
        {
            Invoke("Timer", 1.0f);
        }
        Debug.Log("bool fallObj -> " + fallObj);
    }
    private void Timer()
    {
        fallObj = 0;
        Debug.Log("randomNum = " + randomNum);
    }
    private void CreateObj()
    {
        randomNum = Random.Range(1, 3);
        if (randomNum == 1)
        {
            obj = Instantiate(obj1);
        }
        else if (randomNum == 2)
        {
            obj = Instantiate(obj2);
        }
    }
    private void Original01()
    {
        obj1 = new GameObject();
        obj1.AddComponent<SpriteRenderer>();
        SpriteRenderer sprd = obj1.GetComponent<SpriteRenderer>();
        sprd.sprite = SaveImage.spr1;
        obj1.AddComponent<PolygonCollider2D>();
        obj1.GetComponent<PolygonCollider2D>().enabled = false;
        obj1.AddComponent<Rigidbody2D>();

        Vector2 o1 = Camera.main.ScreenToWorldPoint(new Vector2(0, 300));
        obj1.transform.position = o1;
    }
    private void Original02()
    {
        obj2 = new GameObject();
        obj2.AddComponent<SpriteRenderer>();
        SpriteRenderer sprd = obj2.GetComponent<SpriteRenderer>();
        sprd.sprite = SaveImage.spr2;
        obj2.AddComponent<PolygonCollider2D>();
        obj2.GetComponent<PolygonCollider2D>().enabled = false;
        obj2.AddComponent<Rigidbody2D>();

        Vector2 o2 = Camera.main.ScreenToWorldPoint(new Vector2(0, 200));
        obj2.transform.position = o2;
    }
}
