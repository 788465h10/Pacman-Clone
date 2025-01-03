using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinFinal : MonoBehaviour
{
    public TMP_Text hightScoresText;
    public TMP_Text lastScoresText;
    int lastScores = 0;
    int hightScore = int.MinValue;
    public void Setup(int scores)
    {
        if (scores > hightScore)
        {
            lastScores = hightScore;
            hightScore = scores;
        }
        gameObject.SetActive(true);
        if (lastScores == int.MinValue)
        {
            lastScores = 0;
        }
        hightScoresText.text = hightScore.ToString() + " Points";
        lastScoresText.text = lastScores.ToString() + " Points";
    }
    public void MainmenuButton()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
