using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SFB;

public class SaveImage3 : MonoBehaviour
{
    public RawImage output;
    
    public void Start()
    {

    }
    public void OnClick()
    {
        StartCoroutine(Rick());
    }
    private IEnumerator Rick()
    {
        Debug.Log(OpenImage3.ImageURL3);
        var loa = new WWW(OpenImage3.ImageURL3);
        yield return loa;
        output.texture = loa.texture;
    }
}
