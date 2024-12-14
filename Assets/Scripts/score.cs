using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class score : MonoBehaviour
{
    static private int maxscore = 0;
    private int nowscore = 0;
    private bool isCooldown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nowscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!isCooldown) {
            nowscore++;
            StartCoroutine(Cooldown());
        }
        if(nowscore>maxscore){maxscore=nowscore;}
    }
    IEnumerator Cooldown()
    {
        // クールダウンを開始
        isCooldown = true;
        yield return new WaitForSeconds(2.0f); // 2.0秒間待機
        isCooldown = false; // クールダウン終了
    }
}
