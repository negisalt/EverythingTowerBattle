using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ImageLoader))]
public class ImageLoadTest : MonoBehaviour
{
    // 画像名
    const string PictureFileName = "Discode.png";

    // 画像パス
    string PictureFilePath => System.IO.Path.Combine(Application.streamingAssetsPath, PictureFileName);

    void Start()
    {
        // StreamingAssetsフォルダからファイルを読み込んで表示する
        this.gameObject.GetComponent<ImageLoader>().SetTextureForPanel(PictureFilePath);
    }
}