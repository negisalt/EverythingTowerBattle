using UnityEngine;
using UnityEngine.UI;

public class ScoreManage : MonoBehaviour
{
    public Text scoreText;
    private float score;
    void Start()
    {
        score = GameManage.height;
    }

    void Update()
    {
        score = GameManage.height;
        scoreText.text = "score : " + score;
    }
}
