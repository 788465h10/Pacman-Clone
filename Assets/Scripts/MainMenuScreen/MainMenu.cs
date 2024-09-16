using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Pacman");
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Exit Button Pressed");
    }
}
