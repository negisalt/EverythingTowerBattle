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
    //public RawImage output;
    public GameObject obj;
    public Texture2D tex;
    public Sprite spr;
    
    public void Start()
    {
        obj.AddComponent<SpriteRenderer>();
    }
    public void OnClick()
    {
        StartCoroutine(Spr());
        AddCom();
    }
    private IEnumerator Spr()
    {
        Debug.Log(OpenImage3.ImageURL3);
        var loa = new WWW(OpenImage3.ImageURL3);
        yield return loa;
        //output.texture = loa.texture;
        tex = loa.texture;
        spr = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        //obj.sprite = spr;
    }
    private void AddCom()
    {
        SpriteRenderer sprd = obj.GetComponent<SpriteRenderer>();
        sprd.sprite = spr;
        obj.AddComponent<Rigidbody2D>();
        obj.AddComponent<PolygonCollider2D>();
    }
}
