using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SFB;

public class SaveImage : MonoBehaviour
{
    //public GameObject obj1;
    public Texture2D tex1;
    public Texture2D tex2;
    public Texture2D tex3;
    public static Sprite spr1;
    public static Sprite spr2;
    public static Sprite spr3;

    public void OnClick()
    {
        StartCoroutine(Spr1());
        StartCoroutine(Spr2());
        StartCoroutine(Spr3());
    }
    private IEnumerator Spr1()
    {
        Debug.Log(OpenImage1.imageURL1);
        using (UnityWebRequest loa1 = UnityWebRequestTexture.GetTexture(OpenImage1.imageURL1))
        {
            yield return loa1.SendWebRequest();
            if (loa1.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(loa1.error);
            }
            else
            {
                tex1 = DownloadHandlerTexture.GetContent(loa1);
            }
        }
        /*var loa1 = new WWW(OpenImage1.imageURL1);
        yield return loa1;
        tex1 = loa1.texture;*/
        spr1 = Sprite.Create(tex1, new Rect(0, 0, tex1.width, tex1.height), new Vector2(0.5f, 0.5f));
    }
    private IEnumerator Spr2()
    {
        Debug.Log(OpenImage2.imageURL2);
        using (UnityWebRequest loa2 = UnityWebRequestTexture.GetTexture(OpenImage2.imageURL2))
        {
            yield return loa2.SendWebRequest();
            if (loa2.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(loa2.error);
            }
            else
            {
                tex2 = DownloadHandlerTexture.GetContent(loa2);
            }
        }
        spr2 = Sprite.Create(tex2, new Rect(0, 0, tex2.width, tex2.height), new Vector2(0.5f, 0.5f));
    }
    private IEnumerator Spr3()
    {
        Debug.Log(OpenImage3.imageURL3);
        using (UnityWebRequest loa3 = UnityWebRequestTexture.GetTexture(OpenImage3.imageURL3))
        {
            yield return loa3.SendWebRequest();
            if (loa3.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(loa3.error);
            }
            else
            {
                tex3 = DownloadHandlerTexture.GetContent(loa3);
            }
        }
        spr3 = Sprite.Create(tex3, new Rect(0, 0, tex3.width, tex3.height), new Vector2(0.5f, 0.5f));
    }
}
