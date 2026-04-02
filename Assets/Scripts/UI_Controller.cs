using TMPro;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    public static UI_Controller instance;

    public TMP_Text raceTimeText;
    public TMP_Text countdownText;
    public TMP_Text winnerText;
    public UnityEngine.UI.Image winnerImage;
    public GameObject winPanel;


    public void Awake()
    {
        instance = this;
        winPanel.SetActive(false);
        countdownText.text = "PLACE YOUR BETS";
    }

    void LateUpdate()
    {
        raceTimeText.text = "Time: " + RaceController.raceTime;
    }

    public void ChangeCountdownText(string newText)
    {
        countdownText.text = newText;
    }

    public void SetWinnerPanel(string winner, Sprite sprite)
    {
        winPanel.SetActive(true);
        winnerImage.sprite = sprite;
        winnerImage.GetComponent<Animator>().Play("win");
        winnerText.text = "WINNER: \n" + winner;
    }
}
