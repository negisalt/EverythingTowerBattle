using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ImageLoader : MonoBehaviour
{
    [SerializeField]
    private Image p_TargetImage = null;

    [SerializeField]
    private Material p_BaseMat = null;

    /// <summary>
    /// 開始時処理
    /// </summary>
    public void SetTextureForPanel(string a_ImagePath)
    {
        // 起動時、保存済みの画像ファイルが存在すればテクスチャとして読み込む
        if (System.IO.File.Exists(a_ImagePath))
        {
            byte[] imageBuff = ReadImageFile(a_ImagePath);
            Texture2D imageTexture = BinaryToTexture(imageBuff);

            // テクスチャを反映したマテリアルに差し替える
            Material changeMaterial = new Material(p_BaseMat);
            changeMaterial.SetTexture("_MainTex", imageTexture);
            p_TargetImage.material = changeMaterial;
        }
    }

    /// <summary>
    /// バイナリ読み込み
    /// </summary>
    static public byte[] ReadImageFile(string path)
    {
        using (System.IO.FileStream fileStream = new System.IO.FileStream(
            path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
        {
            System.IO.BinaryReader bin = new System.IO.BinaryReader(fileStream);
            byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);
            bin.Close();
            return values;
        }
    }

    /// <summary>
    /// バイナリ->Texture2D変換
    /// </summary>
    static public Texture2D BinaryToTexture(byte[] bytes)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(bytes);
        return texture;
    }
}