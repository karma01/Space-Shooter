using UnityEngine;
using UnityEngine.UI;

public class ControlWinlosepanel : MonoBehaviour
{
    [SerializeField] private GameObject panel1;

    [SerializeField] private CanvasGroup panel;
    [SerializeField] public GameObject win;
    [SerializeField] private GameObject lost;
    [SerializeField] public Button Pausebutton;


    private void Start()
    {
        Invoke("Oncall", 0.5f);
    }


    private void Oncall()
    {

        panel1 = GameObject.FindWithTag("HealthSystem");
        panel = panel1.transform.Find("HealthWinAndLose/WinadnLosePanel").GetComponent<CanvasGroup>();
        win = panel1.transform.Find("HealthWinAndLose/WinadnLosePanel/youwonbg").gameObject;
        lost = panel1.transform.Find("HealthWinAndLose/WinadnLosePanel/youfailedbg").gameObject;
        Pausebutton = panel1.transform.Find("HealthWinAndLose/PauseButton").GetComponent<Button>();
        GameManagerEnd.endmanager.Registerwinlosepanel(this);           //the reference is sent to gamemanager
    }

    public void WinScreenisOn()
    {
      
        panel.alpha = 1.0f;
        win.SetActive(true);
        Pausebutton.gameObject.SetActive(false);
        Time.timeScale = 0;//////////////
    }

    public void lostScreenisOn()
    {
       
        Pausebutton.gameObject.SetActive(false);
        panel.alpha = 1.0f;
        lost.SetActive(true);
        Time.timeScale = 0;//////////////
    }
}