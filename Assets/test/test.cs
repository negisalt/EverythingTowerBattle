using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadImageFromURL : MonoBehaviour
{
    public string imageUrl = "https://ja.wikipedia.org/wiki/%E3%83%95%E3%82%A1%E3%82%A4%E3%83%AB:View_of_Nagoya_Institute_of_Technology_Entrance,_Tsurumai_Showa_Ward_Nagoya_2021.jpg";
    public RawImage rawImage;

    void Start()
    {
        StartCoroutine(LoadImage());
    }

    IEnumerator LoadImage()
    {
        using (WWW www = new WWW(imageUrl))
        {
            yield return www;
            rawImage.texture = www.texture;
        }
    }
}