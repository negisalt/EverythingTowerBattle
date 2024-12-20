using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalGenerator : MonoBehaviour{

    public GameObject obj;//どうぶつ取得配列
    public Camera mainCamera;//カメラ取得用変数
    public float pivotHeight = 200;//生成位置の基準

    public static int animalNum = 0;//生成された動物の個数を保管
    public static bool isGameOver = false;//ゲームオーバー判定

    private GameObject geneAnimal;//どうぶつ生成（単品）
    public bool isGene;//生成されているか
    public bool isFall;//生成された動物が落下中か

    private void Start()
    {
        Init();
        Original();
    }

    // 初期化処理
    void Init()
    {
        animalNum = 0;
        isGameOver = false;
        Animal.isMoves.Clear();//移動してる動物のリストを初期化
        StartCoroutine(StateReset());
    }

    //自分の画像を持ってくる
    void Original()
    {
        obj = new GameObject();
        obj.AddComponent<SpriteRenderer>();
        SpriteRenderer sprd = obj.GetComponent<SpriteRenderer>();
        sprd.sprite = SaveImage.spr1;
        obj.AddComponent<PolygonCollider2D>();
        obj.AddComponent<Rigidbody2D>(); 
        obj.AddComponent<Animal>();
    }

    // 毎フレーム呼び出される(60fpsだったら1秒間に60回)
    void Update () {

        if (isGameOver)
        {
            return;//ゲームオーバーならここで止める
        }

        if (CheckMove(Animal.isMoves))
        {
            return;//移動中なら処理はここまで
        }

        if (!isGene)//生成されてるものがない
        {
            StartCoroutine(GenerateAnimal());//生成するコルーチンを動かす
            isGene = true;
            return;
        }

        Vector2 v = new Vector2(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, pivotHeight);
        geneAnimal.transform.position = v;
        float roll = Input.GetAxis("Mouse ScrollWheel");
        geneAnimal.transform.Rotate(new Vector3(0, 0, roll));

        if (Input.GetMouseButtonDown(0))//もし（マウス左クリックが押されたら）
        { 
            geneAnimal.GetComponent<Rigidbody2D>().isKinematic = false;//――――物理挙動・オン
            animalNum++;//どうぶつ生成
            isFall = true;//落ちる
        }

        /*else if(Input.GetMouseButton(0))//回転ボタンが押されている間
        {
            geneAnimal.transform.position = v;
        }*/
	}

    // 生成・落下状態をリセットするコルーチン
    IEnumerator StateReset()
    {
        while (!isGameOver)
        {
            yield return new WaitUntil(() => isFall);//落下するまで処理が止まる
            yield return new WaitForSeconds(0.1f);//少しだけ物理演算処理を待つ（ないと無限ループ）
            isFall = false;
            isGene = false;
        }
    }

    // どうぶつの生成コルーチン
    IEnumerator GenerateAnimal()
    {
        while (CameraController.isCollision)
        {
            yield return new WaitForEndOfFrame();//フレームの終わりまで待つ（無いと無限ループ）
            mainCamera.transform.Translate(0,0.1f,0);//カメラを少し上に移動
            pivotHeight += 0.1f;//生成位置も少し上に移動
        }
        geneAnimal = Instantiate(obj, new Vector2(0, pivotHeight), Quaternion.identity);//回転せずに生成
        geneAnimal.GetComponent<Rigidbody2D>().isKinematic = true;//物理挙動をさせない状態にする
    }

    // どうぶつの回転
    // ボタンにつけて使います
    public void RotateAnimal()
    {
        if(!isFall)
            geneAnimal.transform.Rotate(0,0,-30);//30度ずつ回転
    }

    // リトライボタン
    /*public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }*/

    // 移動中かチェック
    bool CheckMove(List<Moving> isMoves)
    {
        if (isMoves == null)
        {
            return false;
        }
        foreach (Moving b in isMoves)
        {
            if (b.isMove)
            {
                //Debug.Log("移動中(*'ω'*)");
                return true;
            }
        }
        return false;
    }
}