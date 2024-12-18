using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
    
    /*public void Start()
    {
        //obj1.AddComponent<SpriteRenderer>();
    }*/
    public void OnClick()
    {
        StartCoroutine(Spr1());
        StartCoroutine(Spr2());
        StartCoroutine(Spr3());
        //AddCom();
    }
    private IEnumerator Spr1()
    {
        Debug.Log(OpenImage1.ImageURL1);
        var loa1 = new WWW(OpenImage1.ImageURL1);
        yield return loa1;
        tex1 = loa1.texture;
        spr1 = Sprite.Create(tex1, new Rect(0, 0, tex1.width, tex1.height), new Vector2(0.5f, 0.5f));
    }
    private IEnumerator Spr2()
    {
        Debug.Log(OpenImage2.ImageURL2);
        var loa2 = new WWW(OpenImage2.ImageURL2);
        yield return loa2;
        tex2 = loa2.texture;
        spr2 = Sprite.Create(tex2, new Rect(0, 0, tex2.width, tex2.height), new Vector2(0.5f, 0.5f));
    }
    private IEnumerator Spr3()
    {
        Debug.Log(OpenImage3.ImageURL3);
        var loa3 = new WWW(OpenImage3.ImageURL3);
        yield return loa3;
        tex3 = loa3.texture;
        spr3 = Sprite.Create(tex3, new Rect(0, 0, tex3.width, tex3.height), new Vector2(0.5f, 0.5f));
    }
    /*private void AddCom()
    {
        SpriteRenderer sprd = obj.GetComponent<SpriteRenderer>();
        sprd.sprite = spr;
        obj.AddComponent<Rigidbody2D>();
        obj.AddComponent<PolygonCollider2D>();
    }*/
}
