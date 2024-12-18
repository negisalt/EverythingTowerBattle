using UnityEngine;

public class CreateObjGame : MonoBehaviour
{
    private int count;
    private Vector2 mouPos;
    private bool leaveMouse;
    private GameObject obj;
    private GameObject obj1;
    void Start()
    {
        obj1 = new GameObject();
        obj1.AddComponent<SpriteRenderer>();
        SpriteRenderer sprd = obj1.GetComponent<SpriteRenderer>();
        sprd.sprite = SaveImage.spr1;
        obj1.AddComponent<PolygonCollider2D>();
        obj1.AddComponent<Rigidbody2D>(); 

        count = 0;
        leaveMouse = true;
    }
    public void Update()
    {
        mouPos = Input.mousePosition;
        if(leaveMouse)
        {
            obj = Instantiate(obj1, new Vector2(0, 30), Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().isKinematic = true;
            count++;
            leaveMouse = true;
            Debug.Log(leaveMouse);
        } else if (leaveMouse == 2)
        {
            /*
            Vector3 obj1Pos = Camera.main.ScreenToWorldPoint(new Vector2(mouPos.x, 100));
            obj1.transform.position = obj1Pos;*/
            if(Input.GetMouseButtonDown(0))
            {
                obj.GetComponent<Rigidbody2D>().isKinematic = false;
                Debug.Log(leaveMouse);
                Invoke("Timer", 2.0f);
            }
        }
    }
    private void Timer()
    {
        leaveMouse = false;
        Debug.Log(leaveMouse);
    }
}
