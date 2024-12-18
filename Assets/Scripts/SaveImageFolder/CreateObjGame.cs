using UnityEngine;

public class CreateObjGame : MonoBehaviour
{
    private int count;
    private Vector2 mouPos;
    private bool leaveMouse;
    private GameObject obj;
    public GameObject obj1;
    void Start()
    {
        obj1 = new GameObject();
        obj1.AddComponent<SpriteRenderer>();
        SpriteRenderer sprd = obj1.GetComponent<SpriteRenderer>();
        sprd.sprite = SaveImage.spr1;
        obj1.AddComponent<PolygonCollider2D>();
        obj1.AddComponent<Rigidbody2D>(); 

        Vector2 o1 = Camera.main.ScreenToWorldPoint(new Vector2(60, 300));
        obj1.transform.position = o1;

        count = 0;
        leaveMouse = true;
    }
    public void Update()
    {
        mouPos = Input.mousePosition;
        Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector2(mouPos.x, 300));
        if(leaveMouse)
        {
            obj = Instantiate(obj1, new Vector2(0, 60), Quaternion.identity);//create object
            obj.GetComponent<Rigidbody2D>().isKinematic = true;
            leaveMouse = false;
            Debug.Log(leaveMouse);
        } else if (!leaveMouse)
        {
            obj.transform.position = pos;
            if(Input.GetMouseButtonDown(0))
            {
                obj.GetComponent<Rigidbody2D>().isKinematic = false;
                //leaveMouse = true;
                Invoke("Timer", 0.5f);
            }
        }
    }
    private void Timer()
    {
        leaveMouse = true;
        Debug.Log(leaveMouse);
    }
}
