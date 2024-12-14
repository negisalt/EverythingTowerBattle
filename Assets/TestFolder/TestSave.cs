using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIを適用
using UnityEngine.SceneManagement; // シーン切り替えに必要

public class TestSave : MonoBehaviour
{
    public int a = 0;
    public static int b = 0;
    public Button plusBtn; // ボタンの参照

    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name+ "@a:::" + a);
        Debug.Log(SceneManager.GetActiveScene().name+ "@b:::" + b);
    }

    public void Plus()//UIボタンを押すと加算される
    {
        a++;
        b++;
        Debug.Log(SceneManager.GetActiveScene().name + "@a:::" + a);
        Debug.Log(SceneManager.GetActiveScene().name + "@b:::" + b);
    }

    public void Change()
    {
        if (SceneManager.GetActiveScene().name == "Select")
        {
            SceneManager.LoadScene("Title");
        }
        else
        {
            SceneManager.LoadScene("Select");
        }
    }
}