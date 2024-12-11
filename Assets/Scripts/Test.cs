using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    puvlic GameObject[] pictures;
    Vector3 mousePosition;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 1.0f;
            Instantiate(RandomObject(), Camera.main.ScreenToWorldPoint(mousePosition), Quaternion.identity;)
        }
    }
    GameObject RandomObject()
    {
        int number = RandomObject.Rnage(0, pictures.Length);
        return pictures[number];
    }
}
