using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TMP_Text scoresText;
    public void Setup(int scores)
    {
        gameObject.SetActive(true);
        scoresText.text = scores.ToString() + " Points";
    }
    public void MainmenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
