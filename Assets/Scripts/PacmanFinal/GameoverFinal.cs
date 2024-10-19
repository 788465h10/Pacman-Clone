using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameoverFinal : MonoBehaviour
{
    public TMP_Text scoresText;
    public void Setup(int scores)
    {
        gameObject.SetActive(true);
        scoresText.text = scores.ToString() + " Points";
    }
    public void MainmenuButton()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
