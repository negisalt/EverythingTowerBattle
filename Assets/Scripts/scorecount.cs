using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class scorecount : MonoBehaviour
{
    private int score = 0;
    public Text textbox;
    void Start()
    {
        score = 0;
        textbox.text = score.ToString();
    }

    void Update()
    {
        if(score < 100){score += 0;}
        textbox.text = score.ToString();
    }
}
