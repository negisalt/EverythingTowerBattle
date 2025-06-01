using UnityEngine;

public class GeneObj : MonoBehaviour
{
    //Collect from SaveImage.cs
    public GameObject original;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(original, new Vector3(0.0f, 20.0f, 0.0f), Quaternion.identity);
        }
    }
    
}
