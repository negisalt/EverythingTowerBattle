using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using SFB;

[RequireComponent(typeof(Button))]
public class OpenImage2 : MonoBehaviour, IPointerDownHandler
{
    public RawImage output;
    public static string imageURL2;

#if UNITY_WEBGL && !UNITY_EDITOR
    //
    // WebGL
    //
    [DllImport("__Internal")]
    private static extern void UploadFile(string gameObjectName, string methodName, string filter, bool multiple);

    public void OnPointerDown(PointerEventData eventData) {
        UploadFile(gameObject.name, "OnFileUpload", ".png, .jpg", false);
    }

    // Called from browser
    public void OnFileUpload(string url2) {
        StartCoroutine(OutputRoutine(url2));
        imageURL2 = url2;
    }
#else
    //
    // Standalone platforms & editor
    //
    public void OnPointerDown(PointerEventData eventData) { }

    void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Title", "", "png", false);
        if (paths.Length > 0)
        {
            StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
        }
    }
#endif

    private IEnumerator OutputRoutine(string url2)
    {
        using (UnityWebRequest loader = UnityWebRequestTexture.GetTexture(url2))
        {
            yield return loader.SendWebRequest();
            if (loader.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(loader.error);
            }
            else
            {
                imageURL2 = url2;
                output.texture = DownloadHandlerTexture.GetContent(loader);
            }
        }
    }
}