using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour {

public AudioClip sound1;
AudioSource audioSource;
private bool isCooldown = false;

 void Start () {
   //Componentを取得
   audioSource = GetComponent<AudioSource>();
   
 }

 void Update () {
   // 左
   if (Input.GetMouseButtonDown(0)&&!isCooldown) {
   //音(sound1)を鳴らす
    audioSource.PlayOneShot(sound1);
    StartCoroutine(Cooldown());
   }
 }
 IEnumerator Cooldown()
    {
        // クールダウンを開始
        isCooldown = true;
        yield return new WaitForSeconds(1.0f); // 1.0秒間待機
        isCooldown = false; // クールダウン終了
    }
}