using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public GameObject[] pictures;
    Vector3 mousePosition;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 1.0f;
            Instantiate(RandomObject(), Camera.main.ScreenToWorldPoint(mousePosition), Quaternion.identity);
        }
    }
    GameObject RandomObject()
    {
        int number = Random.Range(0, pictures.Length);
        return pictures[number];
    }
}
