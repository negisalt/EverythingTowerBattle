using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Transform.localPosition;

public class SaveImage3 : MonoBehaviour
{
    //public RawImage output3;
    public void Start()
    {
        //output3 = texture3;
    }
    public void OnClick()
    {
        Rick();
    }
    public void Rick()
    {
        Debug.Log(OpenImage3.ImageURL3);
    }    
}
