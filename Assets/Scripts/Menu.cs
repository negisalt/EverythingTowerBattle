using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject playPanel;
    [SerializeField] GameObject menuPanel;
    public void ClickStartButton()
    {
        ToPlay();
    }
    public void ToMenu()
    {
        playPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
    public void ToPlay()
    {
        playPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
}
