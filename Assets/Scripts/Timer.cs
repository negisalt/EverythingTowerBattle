using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float second;
    void Start()
    {
        second = 0;
    }

    void Update()
    {
        second += Time.deltaTime;
        timerText.text = "Time : " + second;
    }
}
