using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Pacman");
    }
    public void SettingsButton()
    {
        //i will do something after i add sound
    }
    public void ExitButton()
    {
        Application.Quit();
        //Debug.Log("Exit Button Pressed");
    }
}
