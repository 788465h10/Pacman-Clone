using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameoverFinal : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }
    public void MainmenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
